using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHead : AirBomberEnemy
{
    //Är från test scenen
    //Så ja.

    private float currentrotation;
    public float roationtoAdd;
    public float maxrotation = 45f;

    [Space]
    private float nextspawn;
    public float spawnrate;
    [Space]
    public float projectilearoundplayer = 16f;
    public float radius = 1f;
    private float angle;
    private Vector3 newpos;
    public GameObject something;
    public GameObject[] meteors;
    public GameObject gem;
    public GameObject wizard;

    private bool positvie;
    private bool negative;
    public bool phase2;
    public float halflife;
    private bool playonce;
    private bool spawncrystalonce;

    // Update is called once per frame
    void Start()
    {
        scorescript = GameObject.Find("Score").GetComponent<Score>();
        positvie = true;
        player = GameObject.FindGameObjectWithTag("Player");
        halflife = life / 2;
    }
    void Update()
    {

        if (life < 2 && spawncrystalonce == false)
        {
            //Den spawnar en krystal och så kommer en wizard och saker händer
            spawncrystalonce = true;
            Instantiate(gem, transform.position, Quaternion.identity);
            Instantiate(wizard, new Vector2(-13.44f, -6.81f), Quaternion.identity);
        }
        if (life < halflife && playonce == false)
        {
            //vid halva livet startar phase2
            audioscript.playsound("roar");
            playonce = true;
            phase2 = true;
        }
        //phase 1
        if (phase2 == false)
        {
            StartCoroutine(SpinShot());
        }
        //phase 2
        if (phase2 == true)
        {
            StartCoroutine(Doubletrouble());
        }
    }

    private void Instantiate(object wizard)
    {
        throw new NotImplementedException();
    }

    public IEnumerator SpinShot()
    {
        if (Time.time > nextfire)
        {
            //spawnar skott när skottens rottation går upp och ner

            nextfire = Time.time + firerate;
            Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, currentrotation)));
            if (currentrotation > maxrotation && positvie == true)
            {
                positvie = false;
                negative = true;
            }
            if (currentrotation > -maxrotation && negative == true)
            {
                positvie = true;
                negative = false;
            }
            if (negative == true)
            {
                currentrotation -= roationtoAdd;
            }
            if (positvie == true)
            {
                currentrotation += roationtoAdd;
            }

        }

        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnrate;
            for (int i = 0; i < projectilearoundplayer; i++)
            {
                //Räknar ut en circle runt spelaren.
                angle = i * Mathf.PI * 2f / projectilearoundplayer;
                //ändrar dens position till circlen runt spelaren
                newpos = new Vector3(player.transform.position.x + Mathf.Cos(angle) * radius, player.transform.position.y + Mathf.Sin(angle) * radius, transform.position.z);
                //Spawnar runt splearen.
                Instantiate(something, newpos, Quaternion.identity);
            }
        }

        yield return null;
    }
    public IEnumerator Doubletrouble()
    {

        if (Time.time > nextfire)
        {
            //Spawnar meteorer från en array
            nextfire = Time.time + firerate;
            Instantiate(meteors[UnityEngine.Random.Range(0, meteors.Length)], transform.position, Quaternion.identity);
        }
        yield return null;
    }
}