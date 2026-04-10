using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 180);
        Destroy(gameObject, 7);
    }

    void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.down * (speed + (GameControler.gameSpeed * 1f)) * Time.deltaTime;
    }
}
