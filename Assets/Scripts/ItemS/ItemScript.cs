using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public GameObject explosion;
    public Image Item;
    public Image SecondItem;
    [Space]
    public bool haveSecondItem = false;
    public bool haveitemNuke = false;
    [Space]
    public GameObject eyes;
    public GameObject Eyespawnlocation;


    void Start()
    {
        Eyespawnlocation = GameObject.FindGameObjectWithTag("Eyespawnlocation");
        GameObject itemobjekt = GameObject.FindGameObjectWithTag("Nukelogo");
        GameObject Seconditemobjekt = GameObject.FindGameObjectWithTag("Summoneyes");
        Item = itemobjekt.GetComponent<Image>();
        SecondItem = Seconditemobjekt.GetComponent<Image>();
        Item.enabled = false;
        SecondItem.enabled = false;
    }

    private void Update()
    {
        //Om du har itemet så används det när du trycker knappen
        if (haveitemNuke == true && Input.GetKey(KeyCode.Z))
        {
            audioscript.playsound("nukesound");
            UseNuke(tag);
            Item.enabled = false;
            haveitemNuke = false;
        }
        if (haveSecondItem == true && Input.GetKey(KeyCode.X))
        {
            audioscript.playsound("summoneyes");
            Summoneyes();
            SecondItem.enabled = false;
            haveSecondItem = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ItemNuke")
        {
            Item.enabled = true;
            haveitemNuke = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Item")
        {
            SecondItem.enabled = true;
            haveSecondItem = true;
            Destroy(collision.gameObject);
        }

    }
    public void UseNuke(string tag)
    {
        //Den hittar alla enemies på scenen och förstör alla
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //Tar alla enemies inuti array
        foreach (GameObject target in gameObjects)
        {
            //Skapra en explosion där dom är och förstör objekten
            Vector3 spawnpoint = target.transform.position;
            Instantiate(explosion, spawnpoint, Quaternion.identity);
            GameObject.Destroy(target);
        }
    }
    public void Summoneyes()
    {
        //Skapar ögon vid spelaren 
        var Eyes = Instantiate(eyes, Eyespawnlocation.transform.position, Quaternion.identity);
        Eyes.transform.parent = gameObject.transform;
    }
}