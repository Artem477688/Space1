using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    public float speedMin = 0.5f;
    public float speedMax = 3f;

    private float speed; // переменная для скорости

    private void Start()
    {
        RandomSpeed(); // устанавливаем случайную скорость при старте
        Destroy(gameObject, 5f); // уничтожаем объект через 5 секунд
    }

    void RandomSpeed()
    {
        // задаем случайную скорость в диапазоне от speedMin до speedMax
        speed = Random.Range(speedMin, speedMax);
    }

    // Update вызывается каждый кадр
    void Update()
    {
        // двигаем метеор вниз с учетом скорости и глобальной скорости игры
        transform.position += Vector3.down * (speed + GameControler.gameSpeed) * Time.deltaTime;
    }
}