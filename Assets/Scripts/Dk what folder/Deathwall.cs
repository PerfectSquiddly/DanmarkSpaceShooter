using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathwall : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Testar ut saker just nu så det är en snabb lösning
        //Annars om något nuddar vägen så dör det
        if (collision.gameObject.tag != "Laser" )
        {
            Destroy(collision.gameObject);
        }
    }

}
