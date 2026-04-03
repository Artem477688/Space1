using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7);
    }

    void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.up * (speed + (GameControler.gameSpeed * 0.9f)) * Time.deltaTime;
    }
}
