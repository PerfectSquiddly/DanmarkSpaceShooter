using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{

    //Snälla checka inte den här. det är fan chaos ty.
    //Om du kollar den endå och mår illa sen är det inte mitt fel.

    [Space]
    public PlayerMovement player;
    public BossSpawner Bs;
    public GameObject[] DukeGore;
    [Space]
    public float timer;
    private int direction = 1;
    private int top = 3;
    private int bottom = -3;
    private bool moving = false;
    [Space]
    public GameObject waterexplosion;
    public GameObject Kamehame;
    public GameObject batspawner;
    public GameObject enemyspawner;
    public GameObject[] Enemys;
    [Space]
    public float Yspeed;
    public float XSpeed;
    [Space]
    public int Halflife;//halflife2 confirmed? 
    public int enemylife;
    [Space]
    [Space]
    public float duration;
    [Space]

    private float nextspawn;
    public float spawnrate;
    [Space]
    public GameObject ChildrenSpawnspot;
    public GameObject Children;
    void Start()
    {
        ChildrenSpawnspot = GameObject.FindGameObjectWithTag("childrenspawn");
        Halflife = enemylife / 2 + 1;
        Kamehame.SetActive(false);
        GameObject bs = GameObject.FindGameObjectWithTag("bossspawner");
        Bs = bs.GetComponent<BossSpawner>();

        enemyspawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        batspawner = GameObject.FindGameObjectWithTag("BatSpawner");

        GameObject pm = GameObject.FindGameObjectWithTag("Player");
        player = pm.GetComponent<PlayerMovement>();

        audioscript.audiosrc.Stop();
        audioscript.playsound("roar");
        audioscript.playsound("bossmusic");

        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in Enemys)
        {
            audioscript.playsound("nukesound");
            Vector3 spawnpoint = target.transform.position;
            Instantiate(waterexplosion, spawnpoint, Quaternion.identity);
            GameObject.Destroy(target);
        }
        //batspawner.SetActive(false);
        //enemyspawner.SetActive(false);
    }
    void Update()
    {
        // StartCoroutine(Laser());
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnrate;

            var BossChildren = Instantiate(Children, ChildrenSpawnspot.transform.position, Quaternion.identity);
            BossChildren.transform.parent = gameObject.transform;
        }

        if (transform.position.y >= top)
        {
            direction = -1;
        }

        if (transform.position.y <= bottom)
        {
            direction = 1;
        }
        if (duration > timer)
        {
            timer += Time.deltaTime;
        }
        if (timer < duration)
        {
            transform.Translate(-XSpeed * Time.deltaTime, 0, 0);
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

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && enemylife > 0)
        {
            audioscript.playsound("dukedmg");
            enemylife -= 1;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "Bullet" && enemylife == Halflife)
        {
            Kamehame.SetActive(true);
            audioscript.playsound("roar");

        }

        if (collision.gameObject.tag == "Bullet" && enemylife == 0)
        {
            audioscript.audiosrc.Stop();
            audioscript.playsound("dukekilled");
            audioscript.playsound("overworld");
            foreach (GameObject i in DukeGore)
            {
                Instantiate(i, transform.position, Quaternion.identity);
            }
            Bs.bossalive = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //enemyspawner.SetActive(false);

        }
    }
}