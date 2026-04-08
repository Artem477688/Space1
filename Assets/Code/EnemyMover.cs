using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 2f;
    public float targetY = 0f; // точка, при достижении которой остановится движение

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.down * (speed + GameControler.gameSpeed) * Time.deltaTime;
    
        // Проверяем, если объект еще не достиг целевой Y
        if (transform.position.y > targetY)
        {
            // Продолжаем движение вниз
            transform.position = (Vector2)transform.position + Vector2.down * (speed + GameControler.gameSpeed) * Time.deltaTime;
        }

        if (transform.position.y <= targetY)
        {
            enabled = false; // отключить скрипт, движение перестанет работать
        }
        // Иначе остановиться — ничего не делаем или можем отключить скрипт
    }
}
