using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LoopProject : MonoBehaviour
{

    /// <summary>
    /// 更新时间间隔
    /// </summary>
    float UpdateInterval = 0.5f;
    /// <summary>
    /// 最后时间间隔
    /// </summary>
    float LastInterval;
    /// <summary>
    /// 帧【中间变量 辅助】
    /// </summary>
    float Frames = 0;
    /// <summary>
    /// 当前帧数
    /// </summary>
    float FPS;


    // Use this for initialization
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);//切换场景时不要破坏游戏对象

        Application.targetFrameRate = 60;//目标帧速率



    }
    void Start()
    {
        //if (!HaspLock.Instance.LoginHasp(3)) return;
        //Addressables.LoadAssetAsync<GameObject>("Cube").Completed += LoopProject_Completed; ;
        //if (!HaspLock.Instance.LoginHasp()) return;
        SceneStateController.Instance.SetState(new StartSceneState(), false);
        LastInterval = Time.realtimeSinceStartup;//游戏开始后的实时秒数
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneStateController.Instance != null)
            SceneStateController.Instance.StateUpdate();
        Frames++;
        if (Time.realtimeSinceStartup > LastInterval + UpdateInterval)
        {
            FPS = Frames / (Time.realtimeSinceStartup - LastInterval);
            Frames = 0;
            LastInterval = Time.realtimeSinceStartup;
        }
    }
    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.P))
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.green;
            style.fontSize = 20;
            GUI.Label(new Rect(10, 100, 200, 200), "FPS:" + FPS.ToString("f2"), style);//创建一个Text或者图片列表出现在屏幕上
        }
    }





}



