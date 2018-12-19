using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{

    public Text Countdowntext;
    public float timeleft = 30;
    bool Timeriszero;
    // Use this for initialization
    void Start()
    {
        Countdowntext = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeleft > 0 && Timeriszero == false)
        {
            timeleft -= Time.deltaTime;
            Countdowntext.text = "Time Until Boss : " + Mathf.Round(timeleft);

            if (timeleft < 0)
            {
                Timeriszero = true;
                Countdowntext.text = "Time Until Boss : Right now!";
            }
        }
    }
}
