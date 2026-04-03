using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().score += 5000;
            
            Destroy(this.gameObject);
        }
    }
}
