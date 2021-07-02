using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTexture : MonoBehaviour
{
    public float ScrollY = -0.6f;
    float OffsetY;

    void Update()
    {
        OffsetY = Time.time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, OffsetY);
    }

}
