using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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
            SceneStateController.Instance.SetState(new MainSceneState());
            isRun = false;
        }
    }
    public override void StateEnd()
    {
        base.StateEnd();
    }

}
