using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    //Boss enemey jag lekar omkring med
    //Är  i test scenn du kan kolla om du vill.
    //men jag kommenterar inte sos :(

    public BoxCollider2D boxcollider;
    private float halflife;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject target;
    public float rotationSpeed;
    public bool foundtarget;
    public Animator anim;
    public float timer;
    private bool targetdead;
    public float timetoreachcrystal;
    private bool firstphaseover;

    // Use this for initialization
    void Start ()
    {
        halflife = life / 2;
        phase1 = GameObject.Find("phase1");
        phase1.gameObject.SetActive(false);
        phase2 = GameObject.Find("phase2");
        phase2.gameObject.SetActive(false);
        boxcollider = gameObject.GetComponent<BoxCollider2D>();
        boxcollider.enabled = false;
        target = GameObject.FindGameObjectWithTag("Crystal");
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        //checks if reached the crystal
        if(foundtarget == false)
        {
        StartCoroutine(introduction());
        }
        if (timer > timetoreachcrystal)
        {
            foundtarget = true;
        }
        //if the crystal is not dead startcorutine absorb
        if (foundtarget == true && targetdead == false)
        {
            StartCoroutine(absorb());
        }
        //if the crystal is dead return to normal and start the fight
        if (targetdead == true && firstphaseover == false)
        {
            boxcollider.enabled = true;
            anim.SetTrigger("Return");
            StartCoroutine(firstphase());
        }
        if (life < halflife)
        {
            phase1.SetActive(false);
            firstphaseover = true;
            StartCoroutine(secondphase());
        }
    }

    private IEnumerator absorb()
    {
        if(targetdead == false)
        {
        anim.SetTrigger("Absorb");
        target.transform.localScale += new Vector3(-0.3f, -0.3f, -0.3f) * Time.deltaTime;
            if(target.transform.localScale.x < 0)
            {
                targetdead = true;
                Destroy(target);
            }
        }
        yield return null;
    }
    public IEnumerator introduction()
    {
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemyspeed * Time.deltaTime);
        yield return null;
    }
    public IEnumerator firstphase()
    {
        phase1.gameObject.SetActive(true);
        yield return null;
    }
    public IEnumerator secondphase()
    {
        boxcollider.enabled = false;
        phase2.gameObject.SetActive(true);
        yield return null;
    }
}
