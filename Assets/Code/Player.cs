using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public int score = 0;
    public int health = 5;

    public GameObject shield;


    void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;

            Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = realPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteor")
        {
            shield.SetActive(true);
            Invoke("offShield", 3f);
        }
    }

    private void offShield()
    {

        shield.SetActive(false);

    }







}
