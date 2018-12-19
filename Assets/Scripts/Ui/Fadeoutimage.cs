using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeoutimage : MonoBehaviour
{
    //Gör samma sak som fadeout fast istället är det för bilder.

    private float timer;
    public float timebeforefadein;
    public PlayerMovement playermovement;
    public BossSpawner bs;
    public bool firsttime = false;

    void Awake()
    {
        GameObject mp = GameObject.FindGameObjectWithTag("bossspawner");
        bs = mp.GetComponent<BossSpawner>();

        GameObject pm = GameObject.FindGameObjectWithTag("Player");
        playermovement = pm.GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (playermovement.currentlife == 0 && firsttime == false)
        {
            StartCoroutine(startimer());
            if (timer > timebeforefadein)
            {
                StartCoroutine(FadeImageToFullAlpha(1f, GetComponent<Image>()));
                firsttime = true;
            }
        }
        if (bs.bossalive == false && firsttime == false)
        {
            StartCoroutine(startimer());
            if (timer > timebeforefadein)
            {
                StartCoroutine(FadeImageToFullAlpha(1f, GetComponent<Image>()));
                firsttime = true;
            }
        }
    }
    public IEnumerator FadeImageToFullAlpha(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
    public IEnumerator startimer()
    {
        timer += Time.deltaTime;
        yield return null;
    }
}
