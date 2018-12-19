using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retinazer : Enemydemonmovement
{
    public SpazMatism sm;
    public GameObject spaztism;
    public MechanicalSpawner ms;
    public float extrarotationspeed;

    // Use this for initialization
    void Start()
    {
        scorescript = GameObject.Find("Score").GetComponent<Score>();

        GameObject mechspawner = GameObject.FindGameObjectWithTag("bossspawner");
        ms = mechspawner.GetComponent<MechanicalSpawner>();

        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (transform.position.y >= top)
        {
            direction = -1;
        }
        if (transform.position.y <= bottom)
        {
            direction = 1;
        }
        rotation();
        rb.velocity = new Vector3(0, Yspeed * direction * Time.deltaTime, 0);
        bulletroation = gameObject.transform.rotation.z * 100;

        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            for (int i = 0; i < 4; i++)
            {
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation + extrarotationspeed)));
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation - extrarotationspeed)));
                extrarotationspeed += 2.5f;
            }
        }
        if (extrarotationspeed == 10)
        {
            bulletroation = 0;
            extrarotationspeed = 0;
        }

    }
}
