using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorV1 : MonoBehaviour
{
    public GameObject pickupEffect;
    public float scaleMin = 0.8f;
    public float scaleMax = 1.45f;
    public float rotateMin = 0f;
    public float rotateMax = 180f;
    public Player player;

    private float rotationDirection; // 1 или -1 для выбора направления вращения

    void Start()
    {
        RandomSize();
        RandomRotationDirection(); // выбираем случайное направление вращения
        RandomRotation();
        Destroy(gameObject, 8);
    }

    void RandomRotationDirection()
    {
        // С вероятностью 50% выбираем вращение по часовой или против
        rotationDirection = Random.value < 0.5f ? 1f : -1f;
    }

    void RandomRotation()
    {
        float rotationFactor = Random.Range(rotateMin, rotateMax);
        // Умножаем на направление
        transform.localEulerAngles = Vector3.forward * rotationFactor * rotationDirection;
    }

    void RandomSize()
    {
        float scaleFactor = Random.Range(scaleMin, scaleMax);
        transform.localScale = (Vector2)transform.localScale * scaleFactor;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Enemy")
        {
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(effect, 5);
            Destroy(this.gameObject);
        }

        if (collision.tag == "Bullet")
        {
            // Находим игрока на сцене по тегу
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                Player player = playerObj.GetComponent<Player>();
                if (player != null)
                {
                    player.score += 35000; // Увеличиваем счёт, как хотите
                    player.health -= 1;
                }
                else
                {
                    Debug.LogWarning("Компонент Player не найден у объекта с тегом 'Player'");
                }
            }
            else
            {
                Debug.LogWarning("Объект с тегом 'Player' не найден");
            }

            Destroy(collision.gameObject);
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(effect, 5);
            Destroy(this.gameObject);
        }
    }
}