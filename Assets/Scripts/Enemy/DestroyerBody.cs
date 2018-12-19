using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBody : MonoBehaviour
{
    public int bulletspeed;
    [HideInInspector] public float randomX;
    [HideInInspector] public float randomY;
    [HideInInspector]public float randomZ;

    public float firerate;
    [HideInInspector]public float nextfire;

    [Space]
    public GameObject gore;
    public GameObject bullet;
    public string deathsound;
    public string soundname;
    public float Partlife;
    [HideInInspector] public Animator anim;
    [HideInInspector] public MoveBettwenTargets destroyer;
	// Update is called once per frame
    void Start ()
    {
         destroyer = GameObject.FindGameObjectWithTag("Boss").GetComponent<MoveBettwenTargets>();

        anim = gameObject.GetComponent<Animator>();
    }
	void Update ()
    {
        //Om den dör gör den det
        if (destroyer.life < 1)
        {
            audioscript.playsound(deathsound);
            Instantiate(gore, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        //Räknar ut en random riktning
        randomX = Random.Range(0, 360);
        randomY = Random.Range(0, 360);
        randomZ = Random.Range(0, 360);

        var randomDir = new Vector3(randomX, randomY, randomZ);

        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;

            GameObject randombullet = Instantiate(bullet, transform.position, Quaternion.identity);

            //50% chans att den åker åt up och 50% att den åker ner
            if (Random.value<0.5f)
            {
                randombullet.GetComponent<Rigidbody2D>().velocity = randomDir * -bulletspeed * Time.deltaTime;
            }
            else
            {
                randombullet.GetComponent<Rigidbody2D>().velocity = randomDir * bulletspeed * Time.deltaTime;
            }

        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && Partlife > 0)
        {
            audioscript.playsound(soundname);
            Partlife -= 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet" && Partlife == 0)
        {
            audioscript.playsound(soundname);
            destroyer.life -= 1;
            anim.SetTrigger("death");
            Destroy(collision.gameObject);
        }

    }


}
