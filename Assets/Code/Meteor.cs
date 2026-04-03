using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 8);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().health--;
            if (collision.GetComponent<Player>().health <= 0)
            {
                Destroy(collision.gameObject);

            }
            Destroy(this.gameObject);
        }

        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);


        }
       
    }
}
