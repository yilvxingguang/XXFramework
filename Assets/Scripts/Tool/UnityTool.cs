
using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// unity工具
/// </summary>
public class UnityTool
{
/// <summary>
/// 查找父节点 
/// </summary>
/// <param name="gameObject">物体</param>
/// <param name="count">默认为0 最上层父节点  1 第二层 （限制到2） </param>
/// <returns></returns>
    public static GameObject GetBaseParent(GameObject gameObject,int count=0)
    {
        Transform parent = gameObject.transform;
        GameObject ParentGameObject = gameObject;

        switch (count)
        {
            case 0:
                while (parent != null)
                {
                    ParentGameObject = parent.gameObject;
                    parent = parent.parent;
                }
                break;
            case 1:
                while (parent.parent != null)
                {
                    ParentGameObject = parent.gameObject;
                    parent = parent.parent;
                }
                break;
            case 2:
                while (parent.parent.parent != null)
                {
                    ParentGameObject = parent.gameObject;
                    parent = parent.parent;
                }
                break;
            default:
                break;
        }
        
        //Debug.Log(ParentGameObject.name);
        return ParentGameObject;

    }
}

