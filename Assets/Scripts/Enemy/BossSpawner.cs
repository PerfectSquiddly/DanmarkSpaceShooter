using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public float timer;
    public GameObject victoryscreen;
    public GameObject Boss;
    //   public GameObject Children;
    [Space]
    [HideInInspector]public Vector2 wheretospawn;
    public bool bossspawn;
    public bool bossalive;
    public float timeuntilspawn = 30;

    private void Start()
    {
        bossalive = true;
        victoryscreen.SetActive(false);
    }
    private void Update()
    {
        //Spawner en boss efter en tid om den inte har spawnat innan.
        if (!bossspawn && Time.timeSinceLevelLoad > timeuntilspawn)//30
        {
            wheretospawn = new Vector2(transform.position.x, transform.position.y);
            Instantiate(Boss, wheretospawn, Quaternion.identity);
            bossspawn = true;
            bossalive = true;
        }

        if (bossalive == false)
        {
            StartCoroutine(timerbeforevictory());
        }

    }
    public IEnumerator timerbeforevictory()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            victoryscreen.SetActive(true);
        }
        yield return null;
    }
}
