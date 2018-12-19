using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float deathscore;
    //public float scoretoadd;
    //public float increserate = 15;
    //public float scorecurrentlyadded;

    public Score scorescript;

    public bool Canshoot;
    public float enemyspeed;
    public float life;
    public string soundname;
    public string deathsoundname;
    [Space]
    public GameObject[] gore;
    [Space]
    public GameObject[] Itemlist;
    [Space]
    [HideInInspector] public Vector2 wheretospawn;
    [Space]
    [HideInInspector] public Rigidbody2D rb;

    //Gör som voiden säger
    public void movetoleft()
    {
        transform.Translate(-enemyspeed * Time.deltaTime, 0, 0);
    }
    //Gör sig vid en constant hasthighet.
    public void CanshootFalseMove()
    {
        rb.velocity = new Vector3(-5, 0, 0);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //När den kommer innan för skärmen nuddar den en osynlig vägg som sätter på Canshoot
        if (collision.gameObject.tag == "canshoot")
        {
            scorescript = GameObject.Find("Score").GetComponent<Score>();
            Canshoot = true;
        }
        if (collision.gameObject.tag == "Bullet" && life > 0 && Canshoot == true)
        {
            audioscript.playsound(soundname);
            life -= 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet" && Canshoot == true && life < 1)
        {
            scorescript.scoretoadd += deathscore;
            audioscript.playsound(deathsoundname);
            foreach (GameObject i in gore)
            {
                Instantiate(i, transform.position, Quaternion.identity);
            }
            if (Random.Range(0, 7) == 0)
            {
                wheretospawn = new Vector2(transform.position.x, transform.position.y);
                if (Itemlist.Length > 0)
                {
                    Instantiate(Itemlist[Random.Range(0, Itemlist.Length)], wheretospawn, Quaternion.identity);
                }
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
    /*
    public IEnumerator scorecount()
    {
        if (scorecurrentlyadded < scoretoadd)
        {
            scorecurrentlyadded += Time.deltaTime * increserate;
            addscore = Time.deltaTime * increserate;
            scorescript.currentscore += addscore;
        }
        yield return null;
    }
    */


}
