using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDevil : ShootingEnemy
{

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
        bulletroation = gameObject.transform.rotation.z * 100;
        if (Canshoot == false)
        {
            CanshootFalseMove();
        }
        if (Canshoot == true)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(-enemyspeed, 0, 0);
            StartCoroutine(trippletrippleburst());
        }

    }
    public IEnumerator trippletrippleburst()
    {

        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.4f);
                //Den Spawnar 3 bullets med 0.4f sekunder mellan varje 3 gånger
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation)));
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation - 10)));
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation + 10)));
            }
        }
    }
}
