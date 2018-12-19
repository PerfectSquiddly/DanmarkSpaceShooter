using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningGun : MonoBehaviour
{
    public float SpinnSpeed;
    public Transform player;

    public GameObject bullet;

    public float firerate = 0.5f;
    public float nextfire = 1f;
    Vector2 bulletpos;

    private void Update()
    {
        player = transform.parent;
        transform.RotateAround(player.transform.position, Vector3.forward, SpinnSpeed * Time.fixedDeltaTime);

        //Look Right always
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);

        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Fire();
        }
    }

    private void Fire()
    {
        bulletpos = transform.position;
        Instantiate(bullet, bulletpos, Quaternion.identity);
    }

}
