using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpazMatism : Enemydemonmovement
{
    public MechanicalSpawner ms;

    void Start()
    {
        scorescript = GameObject.Find("Score").GetComponent<Score>();

        GameObject mechspawner = GameObject.FindGameObjectWithTag("bossspawner");
        ms = mechspawner.GetComponent<MechanicalSpawner>();

        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {     
        //Åker upp och ner där 1 är top. 0 är mitten. och -1 är bottom
        timer += Time.deltaTime;
        if (transform.position.y >= top)
        {
            direction = -1;
        }
        if (transform.position.y <= bottom)
        {
            direction = 1;
        }
        transform.Translate(0, Yspeed * direction * Time.deltaTime, 0);
        rotation();
        bulletroation = gameObject.transform.rotation.z * 100;

        //håller sig en distans 10f ifrån spelaren annars åker den fram till honom
        if (Vector2.Distance(transform.position, player.transform.position) > 10f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyspeed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, player.transform.position) < 10f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -enemyspeed * Time.deltaTime);
        }
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation)));

        }
    }
}
