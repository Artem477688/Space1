using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    public int score = 0;
    public int health = 15;
    public GameObject pickupEffect;
    public GameObject shield;
    private bool isInvincible = false;

    void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = realPos;
        }
    }

    void Update()
    {
        
        if (health <= 0)
        {
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(effect, 5);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteor" || collision.tag == "EnemyBullet")
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
        if (collision.tag == "MeteorV1")
        {
            if (!isInvincible)
            {
                // Потенциально можно снизить здоровье или проиграть жизнь
                health -= 3;
                if (health <= 0)
                {
                    GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
                    Destroy(effect, 5);
                    Destroy(gameObject);
                }
                // Активируем щит и неуязвимость
                shield.SetActive(true);
                isInvincible = true;
                Invoke("OffShieldAndInvincible", 6f);
            }
            // уничтожаем метеор
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Shield")
        {
            shield.SetActive(true);
            isInvincible = true;
            Invoke("OffShieldAndInvincible", 3f);

        }
        if (collision.tag == "HPBoost")
        {
            collision.GetComponent<PlayerMenu>().health += 1;
            Destroy(collision.gameObject);
        }
    }

    private void OffShieldAndInvincible()
    {
        shield.SetActive(false);
        isInvincible = false;
    }
}