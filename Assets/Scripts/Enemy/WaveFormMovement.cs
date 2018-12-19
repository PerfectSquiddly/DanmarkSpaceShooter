using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFormMovement : Enemy
{
    public float UpAndDownForce;
    public float FrequencyUpAndDown;

    Vector3 pos;
    private float startTime;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pos = transform.position;
    }
    void Update()
    {
        //Åker i en sin curva 
        pos -= transform.right * Time.deltaTime * enemyspeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * FrequencyUpAndDown) * UpAndDownForce;
    }
}

