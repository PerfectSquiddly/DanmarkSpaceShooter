using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [HideInInspector] public float nextfire;
    public float firerate;
    [HideInInspector] public GameObject player;
    public GameObject enemybullet;
    public float rotationSpeed;
    public float bulletroation;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public void rotation()
    {
        //Roterar till spelaren
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * -rotationSpeed);
    }
    private void Update()
    {
        bulletroation = gameObject.transform.rotation.z * 100;
        rotation();
        if (Canshoot == false)
        {
            CanshootFalseMove();
        }
        if (Canshoot == true)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(-enemyspeed, 0, 0);

            if (Time.time > nextfire)
            {
                //Sjukter 3 bullets i en spread med olika rotationer
                nextfire = Time.time + firerate;
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation)));
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation + 10)));
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation - 10)));
            }
        }
    }
    public IEnumerator Shootrate()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Instantiate(enemybullet, transform.position, Quaternion.identity);

            yield return null;
        }
    }
}
