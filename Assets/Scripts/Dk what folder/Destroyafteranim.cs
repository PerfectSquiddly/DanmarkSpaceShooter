using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyafteranim : MonoBehaviour
{

    //Gör som namnet säger
    //De spelar en animation och när animation är slut så dör det.


    private Animator anim;
    public float timeuntildeath = 1.5f;
    public float timetocomplete = 1.5f;
    public float timer;
    public bool islaser;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        StartCoroutine(timeuntilexplode());
    }
    public IEnumerator timeuntilexplode()
    {

        timer += Time.deltaTime;
        if (timer > timetocomplete)
        {
            Destroy(gameObject);
        }
        if(islaser == true)
        {
        StartCoroutine(timeuntiltrigger());
        }
        yield return null;
    }
    IEnumerator timeuntiltrigger()
    {
        if (timer > timeuntildeath)
        {
            anim.SetTrigger("balldeath");
        }
        yield return null;
    }
}
