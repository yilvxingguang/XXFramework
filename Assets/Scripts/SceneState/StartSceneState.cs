using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using OfficeOpenXml;

public class StartSceneState : ISceneState
{
    private bool isRun = true;
    public StartSceneState() : base("StartScene")
    {
    }
    public override void StateStart()
    {
        base.StateStart();

    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        if (isRun)
        {
            //if (!HaspLock.Instance.LoginHasp(3)) return;
            SceneStateController.Instance.SetState(new MainSceneState());
            isRun = false;
        }
    }
    public override void StateEnd()
    {
        base.StateEnd();
    }

}
