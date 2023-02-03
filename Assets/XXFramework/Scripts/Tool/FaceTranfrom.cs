using System;
using System.Collections.Generic;
using UnityEngine;

public class FaceTranfrom : MonoBehaviour
{
    public Transform target = null;
    public void Update()
    {
        if (target == null)
        {
            transform.LookAt(Camera.main.transform);
        }
        else
        {
            transform.LookAt(target);
        }
        Debug.Log(target.name);
    }
}

