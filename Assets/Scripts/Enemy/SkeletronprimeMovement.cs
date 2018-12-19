using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletronprimeMovement : AirBomberEnemy
{

    public GameObject spinaround;
    public GameObject[] skeletronlaser;


    void Start()
    {
        scorescript = GameObject.Find("Score").GetComponent<Score>();
        //Skapar två lasrar i mitten av skärmen
        Instantiate(skeletronlaser[0], new Vector3(0.2f,0,0), Quaternion.identity);
        Instantiate(skeletronlaser[1], new Vector3(-0.2f,0,0), Quaternion.identity);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RotateAround();
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);

        randomX = Random.Range(0, 360);

        randomY = Random.Range(0, 360);

        randomZ = Random.Range(0, 360);
        //Räknar ut en random direction
        var randomDir = new Vector3(randomX, randomY, randomZ);
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            //Skjuter ut bullets i en random direction med delay
            GameObject randombullet = Instantiate(enemybullet, transform.position, Quaternion.identity);
            if (Random.value < 0.5f)
            {
                randombullet.GetComponent<Rigidbody2D>().velocity = randomDir * -bulletspeed * Time.deltaTime;
            }
            else
            {
                randombullet.GetComponent<Rigidbody2D>().velocity = randomDir * bulletspeed * Time.deltaTime;
            }

        }
    }
    void RotateAround()
    {
        //roterar runt mitten av skärmer
        transform.RotateAround(Vector3.zero, Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
    }
}
