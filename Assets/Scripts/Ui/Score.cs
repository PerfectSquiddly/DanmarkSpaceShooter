using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float addscore;
    public float scoretoadd;
    public float increserate = 15;
    public float scorecurrentlyadded;
    public Text scoretext;
    public float currentscore = 0;
    // Use this for initialization
    void Start()
    {
        scoretext = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score : " + Mathf.Round(currentscore);
        if (scorecurrentlyadded < scoretoadd)
        {
            scorecurrentlyadded += Time.deltaTime * increserate;
            addscore = Time.deltaTime * increserate;
            currentscore += addscore;
        }

    }
}
