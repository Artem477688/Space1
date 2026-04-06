using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    public GameObject laserPrefab;     // Префаб лазера
    public Transform spawnPoint;       // Точка спавна лазера
    public float fireInterval = 0.5f;  // Интервал между выстрелами

    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        // Обновляем таймер
        timer += Time.deltaTime;

        // Если прошло достаточно времени — стрелять
        if (timer >= fireInterval)
        {
            SpawnLaserObject();
            timer = 0f; // сбрасываем таймер
        }
    }

    void SpawnLaserObject()
    {
        if (laserPrefab != null && spawnPoint != null)
        {
            GameObject laser = Instantiate(laserPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody rb = laser.GetComponent<Rigidbody>();
            if (rb != null)
            {
             
            }
            else
            {
               
            }
        }
        else
        {
            Debug.LogWarning("LaserPrefab или spawnPoint не указаны");
        }
    }
}
