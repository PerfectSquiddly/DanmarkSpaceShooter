using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletonprimelaser : MonoBehaviour
{
    public GameObject skeletron;
    public SkeletronprimeMovement skeletronscript;
    [Space]
    public LineRenderer linerend;
    public Transform firepoint;
    public GameObject line;
    [Space]
    public float startrotation;
    public float roationspeed;
    public float maxRotation = 45f;
    public float timer;
    // Use this for initialization
    void Start()
    {
        //Gör en röd sträck som ska var asom en laser
        GameObject laserline = Instantiate(line, gameObject.transform.position, Quaternion.identity);
        linerend = laserline.gameObject.GetComponent<LineRenderer>();
        skeletron = GameObject.FindGameObjectWithTag("Boss");
        skeletronscript = skeletron.gameObject.GetComponent<SkeletronprimeMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (skeletronscript.life < 1)
        {
            Destroy(gameObject);
            linerend.enabled = false;
        }
        if(timer > 3)
        {
        StartCoroutine(rotatebackandforward());
        Shoot();    
        }
    }
    void Shoot()
    {
        //Skikar ut en osynlig sträck och när spelaren nudar den så dör han mengång
        RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.position, -firepoint.right);

        if (hitinfo)
        {
            PlayerMovement player = hitinfo.transform.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.currentlife -= player.currentlife;
            }
            linerend.SetPosition(0, firepoint.position);
            linerend.SetPosition(1, firepoint.position + -firepoint.right * 20);
        }
    }
    public IEnumerator rotatebackandforward()
    {
        //Roterar framåt och sen tillbacks
        transform.rotation = Quaternion.Euler(0f, 0f,  startrotation + maxRotation * Mathf.Sin(Time.time * -roationspeed));
        yield return null;
    }
}
