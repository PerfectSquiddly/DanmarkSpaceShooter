using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBettwenTargets : Enemy
{

    public GameObject[] bodyparts;
    public GameObject[] targets;
    public GameObject bodypart;

    private float waitTime;
    public float startWaitTime;
    public float rotationSpeed;
    public int WhichSpot;

    public float dist;
    // Use this for initialization
    void Start()
    {
        scorescript = GameObject.Find("Score").GetComponent<Score>();

        addparts();
        WhichSpot = Random.Range(0, targets.Length);
        targets[0] = GameObject.Find("LeftUpAndDown");
        targets[1] = GameObject.Find("RightUpAndDown");
    }

    // Update is called once per frame
    void Update()
    {
        parts();

        //Roterar den till targeten
        Vector2 direction = targets[WhichSpot].transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //Gör så den rör sig till positionen
        transform.position = Vector2.MoveTowards(transform.position, targets[WhichSpot].transform.position, enemyspeed * Time.deltaTime);

        if (life < 1)
        {
            audioscript.playsound(deathsoundname);
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, targets[WhichSpot].transform.position) < 0.2f)
        {
            //Om den har kommit innanför en 0.2 distance till targeten går den till en annan target
            if (waitTime <= Time.deltaTime)
            {
                WhichSpot = Random.Range(0, targets.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    public void addparts()
    {
        //Lägger till så många parts man vill ha.        
        for (int i = 0; i < bodyparts.Length; i++)
        {
            //Skapar så många parts man vill ha
            bodyparts[i] = Instantiate(bodypart, transform.position, Quaternion.identity) as GameObject;
        }
    }
    public void parts()
    {
        //Gör det för varje part
        for (int i = 0; i < bodyparts.Length; i++)
        {
            var segment = bodyparts[i];
            //Räknar ut positionerna
            Vector3 positionS = bodyparts[i].transform.position;
            //Räknar ut hur många det finns och deras positoiner så det blir som en orm
            Vector3 targetS = i == 0 ? transform.position : bodyparts[i - 1].transform.position;
            //Rör så den roterar till den framför sig i ormen
            bodyparts[i].transform.rotation = Quaternion.LookRotation(Vector3.forward, (targetS - positionS).normalized);
            //Positionen ska vara en distans ifrån dom andra partsen
            Vector3 diff = positionS - targetS; 
            //Normalizear diff
            diff.Normalize();
            //Sen gör man så alla parts får allt tillsamns
            segment.transform.position = targetS + dist * diff;
        }
    }
}
