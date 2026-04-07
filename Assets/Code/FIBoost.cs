using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIBoost : MonoBehaviour
{
    private SpawnLaser spawnLaserScript; // Ссылка на скрипт SpawnLaser

    public float decreaseAmount = 0.1f; // Величина уменьшения
    public float minInterval = 0.01f;   // Минимальное допустимое значение

    
    public GameObject pickupEffect;

    private void Start()
    {
          spawnLaserScript = GetComponent<SpawnLaser>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Получаем SpawnLaser с объекта игрока
            SpawnLaser playerLaser = collision.GetComponent<SpawnLaser>();
            if (playerLaser != null)
            {
                ReduceFireInterval(playerLaser); // передаём нужный компонент
            }

            // Визуальный эффект (по желанию)
            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            Destroy(gameObject); // Удаляем бустер
        }
    }

    // Передаём сюда SpawnLaser нужного объекта
    public void ReduceFireInterval(SpawnLaser targetLaser)
    {
        targetLaser.fireInterval -= decreaseAmount;
        if (targetLaser.fireInterval < minInterval)
            targetLaser.fireInterval = minInterval;
    }


}