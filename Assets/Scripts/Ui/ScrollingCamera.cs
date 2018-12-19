using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCamera : MonoBehaviour
{
    public float scrollspeed = 20f;

    void Update()
    {
        Vector2 offset = new Vector2(Time.time * scrollspeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
