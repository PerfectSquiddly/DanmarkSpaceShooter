using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalSpawner : BossSpawner
{
    public SpazMatism sm;
    public Retinazer rz;
    public MoveBettwenTargets ms;
    public SkeletronprimeMovement spm;
    private bool spazmatismisalive = true;
    private bool retinazerisalive = true;


    public GameObject firsteyeboss;
    public GameObject secondeyeboss;
    public GameObject thirdboss;
    private bool playonce;
    private bool playoncesecond;
    private bool playoncethird;
    private bool stopplz;

    private bool firstbossdead = false;
    private bool secondbossdead = false;
    // Use this for initialization
    void Start()
    {
        victoryscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnin());
    }
    public IEnumerator spawnin()
    {
        if (!bossspawn && Time.timeSinceLevelLoad > 30)//30
        {
            //Efter 30 sekundar spawnas Destroyer
            wheretospawn = new Vector2(15f, 0f);
            Instantiate(Boss, wheretospawn, Quaternion.identity);
            ms = GameObject.FindGameObjectWithTag("Boss").GetComponent<MoveBettwenTargets>();
            bossspawn = true;
        }
        if (bossspawn == true && ms.life < 1)
        {
            firstbossdead = true;
        }
        if (firstbossdead == true && playonce == false)
        {
            //Om första bossen är död så spawnar den the twins på två bestämmda positoner
            playonce = true;
            yield return new WaitForSeconds(1);
            Instantiate(secondeyeboss, new Vector2(6.96f, -4f), Quaternion.identity);
            Instantiate(firsteyeboss, new Vector2(6.96f, 0f), Quaternion.identity);

            GameObject spaztism = GameObject.Find("Spaztism(Clone)");
            sm = spaztism.GetComponent<SpazMatism>();

            GameObject retinazer = GameObject.Find("Retinazer(Clone)");
            rz = retinazer.GetComponent<Retinazer>();
            bossspawn = true;
        }

        //kollar om twins är vi liv
        if (firstbossdead == true && secondbossdead == false)
        {
            if (rz.life < 1)
            {
                retinazerisalive = false;
            }
            if (sm.life < 1)
            {
                spazmatismisalive = false;
            }
            if (spazmatismisalive == false && retinazerisalive == false)
            {
                secondbossdead = true;
            }
        }

        if (secondbossdead == true && playoncesecond == false)
        {
            //Om andra bossen är död så spawnar den 3 bossen
            playoncesecond = true;
            yield return new WaitForSeconds(1);
            Instantiate(thirdboss, new Vector2(4f, 0f), Quaternion.identity);
            spm = GameObject.FindGameObjectWithTag("Boss").GetComponent<SkeletronprimeMovement>();
        }

        if (playoncesecond == true && spm.life < 1 && secondbossdead == true && playoncethird == false)
        {
            playoncethird = true;
            //om alla bossar är döda så startar theme
            StartCoroutine(timerbeforevictory());
        }
    }
}
