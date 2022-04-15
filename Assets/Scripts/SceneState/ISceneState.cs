using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 场景状态基类
/// </summary>
public class ISceneState
{
    protected Transform mCanvas;
    public string sceneName;
    protected GameObject player;

    public ISceneState(string scenename)
    {
        sceneName = scenename;
    }

    /// <summary>
    /// 状态开始调用
    /// </summary>
    public virtual void StateStart() {
        //if (!HaspLock.Instance.LoginHasp()) return;
        mCanvas = GameObject.Find("CanvasUI").transform; player = GameObject.Find("Player"); }
    /// <summary>
    /// 状态更新调用
    /// </summary>
    public virtual void StateUpdate() { }
    /// <summary>
    /// 状态结束调用
    /// </summary>
    public virtual void StateEnd() { }
}
