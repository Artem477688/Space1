using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public GameObject pickupEffect;
    public GameObject shield;
    private bool isInvincible = false;
    public float minX = 0.8f; // минимальная граница по X
    public float maxX = 2f;   // максимальная граница по X
    public float yThreshold = 0.8f; // погрешность по Y
    public float checkRadius = 0.1f; // радиус для проверки коллайдеров
    public LayerMask meteorLayer; // слой объектов Meteor
    public LayerMask bulletLayer; // слой объектов Bullet

    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 180);
    }

    void ChangeXPosition()
    {
        float currentX = transform.position.x;

        // выбираем новое X из диапазона±0.8 от текущего, но не выходя за границы карты
        float minRange = Mathf.Max(currentX - 0.8f, minX);
        float maxRange = Mathf.Min(currentX + 0.8f, maxX);

        float newX = Random.Range(minRange, maxRange);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        // Проверяем все объекты на нужных слоях
        Collider2D[] meteors = Physics2D.OverlapCircleAll(transform.position, checkRadius, meteorLayer);
        Collider2D[] bullets = Physics2D.OverlapCircleAll(transform.position, checkRadius, bulletLayer);

        foreach (var collider in meteors)
        {
            if (Mathf.Abs(collider.transform.position.y - transform.position.y) <= yThreshold)
            {
                ChangeXPosition();
                break; // если с одним объектом нашли совпадение, можно выйти
            }
        }

        foreach (var collider in bullets)
        {
            if (Mathf.Abs(collider.transform.position.y - transform.position.y) <= yThreshold)
            {
                ChangeXPosition();
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteor" || collision.tag == "Bullet")
        {
            if (!isInvincible)
            {
                // Потенциально можно снизить здоровье или проиграть жизнь
                health--;
                if (health <= 0)
                {
                    GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
                    Destroy(effect, 5);
                    Destroy(gameObject);
                }
                // Активируем щит и неуязвимость
                shield.SetActive(true);
                isInvincible = true;
                Invoke("OffShieldAndInvincible", 3f);
            }
            // уничтожаем метеор
            Destroy(collision.gameObject);
        }
    }

    private void OffShieldAndInvincible()
    {
        shield.SetActive(false);
        isInvincible = false;
    }
}
