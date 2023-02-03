using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// DrillScene 场景
/// </summary>
public class DrillSceneState : ISceneState
{
    /// <summary>
    /// 建筑名字
    /// </summary>
    private string BuildName;
    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="name"></param>
    public DrillSceneState(string name) : base("DrillScene")
    {
        BuildName = name;
    }

    public override void StateStart()
    {
        base.StateStart();
    
    }

    public override void StateUpdate()
    {
        base.StateUpdate();

       if(Input.GetKeyDown(KeyCode.K))
        {
            mCanvas.gameObject.SetActive(!mCanvas.gameObject.activeSelf);
        }
    }

    public override void StateEnd()
    {
        base.StateEnd();
        //清理
        //HandleSystem.Instance.ClearEndDrillScene();
    }
}
