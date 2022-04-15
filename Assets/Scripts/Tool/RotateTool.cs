using System;
using System.Collections.Generic;
using UnityEngine;

public class RotateTool:MonoBehaviour
{
    public float Speed=4;
    public void Update()
    {
        transform.Rotate(Vector3.up*Time.deltaTime*Speed);
    }
}

