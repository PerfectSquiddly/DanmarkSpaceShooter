using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardCircleShot : SpreadShootingenemy {

    //Boss enemey jag lekar omkring med
    //Är  i test scenn du kan kolla om du vill.
    //men jag kommenterar inte sos :(

    public float SpinnSpeed;
	void Start ()
    {
        player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(lateSpreadShot());
        transform.RotateAround(player.transform.position, Vector3.forward, SpinnSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.AngleAxis(0, -Vector3.forward);
    }
    public IEnumerator lateSpreadShot()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            for (int i = 0; i < 9; i++)
            {
                yield return new WaitForSeconds(0.1f);
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation)));
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, -bulletroation)));
                bulletroation += rotationtoadd;
            }
        }
        if (bulletroation == maxrotation)
        {
            bulletroation = 0;
        }
    }
    
}
