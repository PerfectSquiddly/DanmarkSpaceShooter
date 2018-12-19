using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemon : BulletScript
{
    public float timer = 0;
    public float spinspeed;


    // Update is called once per frame
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Rotate(0, 0, 1 * spinspeed * Time.deltaTime);
        StartCoroutine(slowbullet());
    }
    public IEnumerator slowbullet()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            //Den väntar 3 sekunden och sen så åker den
            rb.velocity = new Vector2(velocityX, velocityY);
        }
        yield return null;
    }
}
