using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : BulletScript
{
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = transform.right * -velocityX;
    }
}
