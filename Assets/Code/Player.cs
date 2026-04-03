using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;
    public int health = 5;

    public GameObject shield;
    private bool isInvincible = false; // ‘лаг неу€звимости

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
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteor" && !isInvincible)
        {
            shield.SetActive(true);
            isInvincible = true; // ¬ключаем неу€звимость
            Invoke("offShield", 3f);
            Invoke("offInvincible", 3f); // ¬ыключаем неу€звимость через 3 секунды
        }
    }

    private void offShield()
    {
        shield.SetActive(false);
    }

    private void offInvincible()
    {
        isInvincible = false;
    }
}