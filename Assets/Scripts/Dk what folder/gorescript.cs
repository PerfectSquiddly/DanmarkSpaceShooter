using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gorescript : MonoBehaviour
{
    Rigidbody2D rb;
    public float thrustRight;
    public float thrustUpwards;

    void Start()
    { 
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * thrustUpwards);
        rb.AddForce(transform.right * thrustRight);
    }
}
