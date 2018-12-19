using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovetoLeft : MonoBehaviour
{
    public float leftspeed;
    void Update()
    {
        transform.Translate(-leftspeed * Time.deltaTime, 0, 0);
    }
}
