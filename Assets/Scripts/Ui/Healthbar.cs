using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public PlayerMovement pm;
    public Image bar;

    private void Start()
    {
        GameObject mp = GameObject.FindGameObjectWithTag("Player");
        pm = mp.GetComponent<PlayerMovement>();
        bar = GetComponent<Image>();
    }

    void Update()
    {
        //Räknar ut hur ifylld hp baren ska vara
        bar.fillAmount = pm.currentlife / pm.playerlife;
    }
}
