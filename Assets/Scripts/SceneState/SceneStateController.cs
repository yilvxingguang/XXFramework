using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class SceneStateController : Singleton<SceneStateController>
{
    public string SceneName;
    public AsyncOperation asyncOperation;
    public bool isRunState;

    private ISceneState sceneSate;
    private LoadingPanel loadingPanel;

    /// <summary>
    /// 跳转场景
    /// </summary>
    /// <param name="scenestate"></param>场景名字
    /// <param name="isLoading"></param>是否需要加载界面
    /// <param name="isLoadScene"></param>是否卸载场景换新场景
    public void SetState(ISceneState scenestate, bool isLoadScene = true, string loadingName = "Loading")
    {
        if (sceneSate != null)//场景是否为空
        {
            sceneSate.StateEnd(); //上一个场景的清理工作
        }
        sceneSate = scenestate;
        SceneName = sceneSate.sceneName;


        if (isLoadScene)//加载场景是否为空
        {
            isRunState = false;
            GameObject loading = GameObject.Instantiate(Resources.Load("Prefabs/UIPrefabs/LoadingUI/" + loadingName) as GameObject);//实例化Loading场景
            loadingPanel = loading.AddComponent<LoadingPanel>();//添加代码到Loading界面
            loadingPanel.SceneSate = sceneSate;
        }
        else
        {
            StateRun();
        }
    }
    public void StateUpdate()//状态更新
    {
        if (sceneSate != null && isRunState)
        {
            sceneSate.StateUpdate();

        }
        if (asyncOperation != null && asyncOperation.isDone)//异步加载是否完成
        {
            StateRun();
            asyncOperation = null;
        }
    }
    public void StateRun()//状态运行
    {
        isRunState = true;
        sceneSate.StateStart();//状态开始调用
    }
}
