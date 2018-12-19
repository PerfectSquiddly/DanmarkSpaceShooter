using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookattarget : BulletScript
{
    public GameObject target;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        findtarget();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * velocityX;
    }
    public void findtarget()
    {
        if (target != null)
        {
            //Om targeten hittades så rotterar den mot den
            var dir = target.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
