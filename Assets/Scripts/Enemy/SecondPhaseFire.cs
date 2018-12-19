using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPhaseFire : MonoBehaviour
{
    //In progress
    // Uwu

    public Rigidbody2D rb;
    public float speed;
    public float Fallspead;
    public bool isrising;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isrising)
        {
            risingdown();
        }
        else if (isrising == true)
        {
            risingup();
        }
    }

    void risingup()
    {
        rb.gravityScale = 0;
        rb.AddForce(Vector2.up * speed);
    }
    void risingdown()
    {
        rb.gravityScale = Fallspead;
    }
}
