using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject pickupEffect;
    public float scaleMin = 0.8f;
    public float scaleMax = 1.45f;
    public float rotateMin = 0f;
    public float rotateMax = 180f;

    void Start()
    {
        RandomSize();
        RandomRotation();
        Destroy(gameObject, 8);
    }

    void RandomRotation()
    {
       float rotationFactor = Random.Range(rotateMin, rotateMax);
        transform.localEulerAngles = Vector3.forward * rotationFactor;
    }

    void RandomSize()
    {
        float scaleFactor = Random.Range(scaleMin, scaleMax);
        transform.localScale = (Vector2)transform.localScale * scaleFactor;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(effect, 5);
            Destroy(this.gameObject);
        }

        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(effect, 5);
            Destroy(this.gameObject);


        }
       
    }
}
