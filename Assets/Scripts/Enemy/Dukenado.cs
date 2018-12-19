using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dukenado : MonoBehaviour
{
    //Som med bossenemy. Scriptet är fan chaos
    //Kolla inte snälla. den finns inte i scenen längre
    // <3


    public float SpinnSpeed;
    public Transform player;

    public float buletspeed;
    public float EnemySpeed;
    public int enemylife;
    [Space]
    public float nextfire;
    public float firerate;
    [Space]
    public GameObject enemybullet;
    public Vector2 enemybulletpos;

    void Update()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            enemybulletpos = transform.position;

            GameObject TBullet = Instantiate(enemybullet, enemybulletpos, Quaternion.Euler(new Vector3(0, 0, 20))) as GameObject;

            TBullet.GetComponent<Rigidbody2D>().velocity = TBullet.transform.right * buletspeed;

            GameObject TBullet2 = Instantiate(enemybullet, enemybulletpos, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

            TBullet2.GetComponent<Rigidbody2D>().velocity = TBullet2.transform.right * buletspeed;

            GameObject TBullet3 = Instantiate(enemybullet, enemybulletpos, Quaternion.Euler(new Vector3(0, 0, 345))) as GameObject;

            TBullet3.GetComponent<Rigidbody2D>().velocity = TBullet3.transform.right * buletspeed;
        }
        player = transform.parent;
        transform.RotateAround(player.transform.position, Vector3.forward, SpinnSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.AngleAxis(0, Vector3.zero);

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && enemylife > 0)
        {
            enemylife -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bullet" && enemylife == 0)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
