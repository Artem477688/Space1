using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBoost : MonoBehaviour
{
    public GameObject pickupEffect;

    void Start()
    {
        Destroy(gameObject, 8);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().health += 1;
            collision.GetComponent<PlayerMenu>().health += 1;
            Destroy(this.gameObject);
        }
    }
}

