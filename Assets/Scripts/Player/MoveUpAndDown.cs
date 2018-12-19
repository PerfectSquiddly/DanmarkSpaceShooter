using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : Enemydemonmovement
{
    public float maxtop = 5;
    public float mintop = -5;
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y >= maxtop)
        {
            direction = -1;
        }

        if (transform.position.y <= mintop)
        {
            direction = 1;
        }
        //Gör så den rör sig upp och ner det 
        //När den är vid mintop så går den upp och när den är vid maxtop går den ner
        transform.Translate(0, Yspeed * direction * Time.deltaTime, 0);
    }
}
