using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{

    public GameObject MeteorPrefab;    
    public Transform spawnPoint;       
    public float fireInterval = 0.5f;

    private float timer;




    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Обновляем таймер
        timer += Time.deltaTime;

        // Если прошло достаточно времени — стрелять
        if (timer >= fireInterval)
        {
            SpawnMeteorite();
            timer = 0f; // сбрасываем таймер
        }
    }

    void SpawnMeteorite()
    {

        if (MeteorPrefab != null && spawnPoint != null)
        {
            GameObject meteor = Instantiate(MeteorPrefab, spawnPoint.position + Vector3.right * Random.Range(-2f, 2f), Quaternion.identity);
            Rigidbody rb = meteor.GetComponent<Rigidbody>();
            if (rb != null)
            {

            }






        }


    }

}
