using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : Enemy
{
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //StartCoroutine(scorecount());
        if (Canshoot == false)
        {
            CanshootFalseMove();
        }
        if (Canshoot == true)
        {
            //Rör sig mot spelaren.
            movetoleft();   
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyspeed * Time.fixedDeltaTime);
        }
    }
}
