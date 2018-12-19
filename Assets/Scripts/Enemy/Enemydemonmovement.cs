using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydemonmovement : ShootingEnemy
{
    public bool moving = false;
    public float duration;
    public float Yspeed = 5;
    [HideInInspector] public float timer;
    [HideInInspector] public int direction = 1;
    public int top = 5;
    public int bottom = -5;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //När den nuddar den osynliga väggen så börjar den röra sig som den ska
        if (Canshoot == true)
        {
            StartCoroutine(movement());
        }
        if (Canshoot == false)
        {
            movetoleft();
        }
        if (moving == false && Canshoot == true)
        {
            StartCoroutine(Shootrate());
        }
    }
    public IEnumerator movement()
    {
        //Den åker fram i några sekunder och sen åker den upp och ner och börjar spawnna bullets.

        timer += Time.deltaTime;
        if (transform.position.y >= top)
        {
            direction = -1;
        }

        if (transform.position.y <= bottom)
        {
            direction = 1;
        }
        if (timer < duration)
        {
            transform.Translate(-enemyspeed * Time.deltaTime, 0, 0);
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving == false)
        {
            transform.Translate(0, Yspeed * direction * Time.deltaTime, 0);
        }
        yield return null;
    }
}
