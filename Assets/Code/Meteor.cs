using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().health--;
           if(collision.GetComponent<Player>().health <= 0)
            {
               Destroy(collision.gameObject);
               Destroy(this.gameObject);
            }
                
        }
    }


}
