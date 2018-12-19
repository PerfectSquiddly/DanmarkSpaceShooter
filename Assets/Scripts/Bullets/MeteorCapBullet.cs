using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCapBullet : Lookattarget
{
    float randomX;
    float randomY;
    float randomZ;
    Vector3 randomDir;
    public float timer = 0;
    private bool targetfound;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

        //Skapar en random riktning i en circle
        randomX = Random.Range(-180, 180);

        randomY = Random.Range(-180, 180);

        randomZ = Random.Range(-180, 180);

        randomDir = new Vector3(randomX, randomY, randomZ);
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(waitbeforefire());
    }
    public IEnumerator waitbeforefire()
    {
        //Väntar i ett par sekunder och när targetfound = true så åker den mot spelaren
        if (timer < 2)
        {
            timer += Time.deltaTime;
            rb.velocity = randomDir * -2.5f * Time.deltaTime;
        }
        if (timer > 2)
        {
            rb.velocity = new Vector2(0, 0);
            if (targetfound == false)
            {
                findtarget();
                yield return new WaitForSeconds(0.05f);
                targetfound = true;
            }
            if (targetfound == true)
            {
                rb.velocity = transform.right * -velocityX;
            }

        }
    }
}
