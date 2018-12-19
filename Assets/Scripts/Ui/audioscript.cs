using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioscript : MonoBehaviour
{
    //Skapar en funktion som man kan kolla på i andra scripts för att få den specifka ljudefekten

    public static AudioClip bossmusic, overworld, bow, enemydead, takedmg, toughdmg, dukedmg, dukekilled, nukesound, summoneyes, roar, saucerdmg, saucerdead, meteordmg, meteordead;
    public static AudioSource audiosrc;
    // Use this for initialization
    void Start()
    {
        meteordead = Resources.Load<AudioClip>("meteordead");
        meteordmg = Resources.Load<AudioClip>("meteordmg");
        saucerdead = Resources.Load<AudioClip>("saucerdead");
        saucerdmg = Resources.Load<AudioClip>("saucerdmg");
        roar = Resources.Load<AudioClip>("roar");
        summoneyes = Resources.Load<AudioClip>("summoneyes");
        nukesound = Resources.Load<AudioClip>("nukesound");
        dukekilled = Resources.Load<AudioClip>("dukekilled");
        dukedmg = Resources.Load<AudioClip>("dukedmg");
        toughdmg = Resources.Load<AudioClip>("toughdmg");
        takedmg = Resources.Load<AudioClip>("takedmg");
        enemydead = Resources.Load<AudioClip>("enemydead");
        bow = Resources.Load<AudioClip>("bow");
        overworld = Resources.Load<AudioClip>("overworld");
        bossmusic = Resources.Load<AudioClip>("bossmusic");
        audiosrc = gameObject.GetComponent<AudioSource>();
    }
    public static void playsound(string clip)
    {
        switch (clip)
        {
            case "bossmusic":
                audiosrc.PlayOneShot(bossmusic);
                break;

            case "overworld":
                audiosrc.PlayOneShot(overworld);
                break;

            case "bow":
                audiosrc.PlayOneShot(bow);
                break;

            case "enemydead":
                audiosrc.PlayOneShot(enemydead);
                break;

            case "takedmg":
                audiosrc.PlayOneShot(takedmg);
                break;

            case "toughdmg":
                audiosrc.PlayOneShot(toughdmg);
                break;

            case "dukedmg":
                audiosrc.PlayOneShot(toughdmg);
                break;

            case "dukekilled":
                audiosrc.PlayOneShot(dukekilled);
                break;

            case "nukesound":
                audiosrc.PlayOneShot(nukesound);
                break;

            case "summoneyes":
                audiosrc.PlayOneShot(summoneyes);
                break;
            case "roar":
                audiosrc.PlayOneShot(roar);
                break;
            case "saucerdmg":
                audiosrc.PlayOneShot(saucerdmg);
                break;
            case "saucerdead":
                audiosrc.PlayOneShot(saucerdead);
                break;
            case "meteordmg":
                audiosrc.PlayOneShot(meteordmg);
                break;
            case "meteordead":
                audiosrc.PlayOneShot(meteordead);
                break;
        }
    }
}
