using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWaterHeight : MonoBehaviour
{
    public Transform Target;
    private MeshRenderer m;
    private Material material;
    private Vector3 LastPos;
    private List<float> ArrLastPos;
    private float force;
    private float damp;
    private float JitterScale;

    // Use this for initialization
    void Start()
    {
        m = transform.GetComponent<MeshRenderer>();
        if (m != null) material = m.material;
        LastPos = transform.position;
        ArrLastPos = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if (material != null && Target != null)
        {
            __SetCurrentPos();
            //__TheJitter();
        }
        if (Input.GetMouseButtonDown(0))
        {
            damp = 0.3f;
        }
    }

    /// <summary>
    /// 设置当前位置
    /// </summary>
    private void __SetCurrentPos()
    {
        material.SetFloat("_LevelOfWaterX", Target.position.x);
        material.SetFloat("_LevelOfWaterY", Target.position.y);
        material.SetFloat("_LevelOfWaterZ", Target.position.z);
    }

    /// <summary>
    /// 抖动计算
    /// </summary>
    private void __TheJitter()
    {
        //顺序不可变
        if (transform.position == LastPos && ArrLastPos.Count != 0)
        {
            float distance = 0;
            for (int i = 0; i < ArrLastPos.Count; i++)
            {
                distance += ArrLastPos[i];
            }
            distance /= ArrLastPos.Count;
            damp = distance * 15f;

            ArrLastPos = new List<float>();
        }

        if (transform.position != LastPos)
        {
            ArrLastPos.Add(Vector3.Distance(transform.position, LastPos));
            LastPos = transform.position;
        }

        if (damp != 0)
        {
            force += 0.5f;
            if (damp < 0.005f)
            {
                damp = 0;
            }

            JitterScale = Mathf.Sin(force) * damp;
            material.SetFloat("_LevelOfWaterOffsetScale", JitterScale);
            damp *= 0.95f;
        }
    }
}
