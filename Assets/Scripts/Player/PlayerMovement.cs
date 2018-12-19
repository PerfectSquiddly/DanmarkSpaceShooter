using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float PlayerSpeed = 5;
    public GameObject gameoverscreen;
    public GameObject bullet;
    private Rigidbody2D rb;

    public float firerate = 0.5f;
    [HideInInspector]public float nextfire = 1f;
    public float damagetotake;
    Vector2 bulletpos;

    Animator anim;
    public float nextdmgtake;
    public float dmgrate;

    public float playerlife;
    public float currentlife;

    // Update is called once per frame
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentlife = playerlife;
        gameoverscreen = GameObject.FindGameObjectWithTag("Gameover");
        gameoverscreen.SetActive(false);
    }
    void Update()
    {
        //Simple movment
        anim.SetTrigger("Return");
        float momento = Input.GetAxisRaw ("Vertical");
        float momenmonto = Input.GetAxisRaw ("Horizontal");
        rb.velocity = new Vector2(momenmonto, momento) * PlayerSpeed * Time.fixedDeltaTime * 100;

        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Fire();
        }

        if (currentlife < 1)
        {
            //Om du dör så säts gameoverscreen på
            gameObject.SetActive(false);
            gameoverscreen.SetActive(true);
        }
    }

    private void Fire()
    {
        audioscript.playsound("bow");
        bulletpos = transform.position;
        Instantiate(bullet, bulletpos, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "EnemyBullet")
        {
            audioscript.playsound("takedmg");
            anim.SetTrigger("PlayerTakeDamage");
            Destroy(collision.gameObject);
            currentlife -= damagetotake;

        }
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("PlayerTakeDamage");
            audioscript.playsound("takedmg");
            Destroy(collision.gameObject);
            currentlife -= damagetotake;
        }

        if (collision.gameObject.tag == "Laser")
        {
            audioscript.playsound("takedmg");
            currentlife -= currentlife;
        }
        if (collision.gameObject.tag == "Boss" && Time.time > nextdmgtake)
        {
            anim.SetTrigger("PlayerTakeDamage");
            nextdmgtake = Time.time + dmgrate;
            audioscript.playsound("takedmg");
            currentlife -= damagetotake;
        }
    }
}
