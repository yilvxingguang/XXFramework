using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 标头
/// </summary>
public class TotalPanel : IPanel
{
    GameObject LoginBtn;
    private ISceneState backSceneState;
    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="isActiveBack">是否有返回键</param>
    public TotalPanel(bool isActiveBack = false) : base("CommonPanel/TotalPanel", "UIObject")
    {
        UIObject.transform.Find("BackBtn").gameObject.SetActive(isActiveBack);
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void UIAssignment()
    {
        base.UIAssignment();
        ButtonsAddEvent();
    }
    public void SetBackScene(ISceneState backScene)
    {
        backSceneState = backScene;
    }
    /// <summary>
    /// 按钮事件
    /// </summary>
    private void ButtonsAddEvent()
    {
        UIObject.transform.Find("BackBtn").GetComponent<Button>().onClick.AddListener(delegate
        {
            SceneStateController.Instance.SetState(backSceneState);

            GameObject.Find("LoopProject").GetComponent<AudioSource>().Stop();
            
        });
        //UIObject.transform.Find("SetBtn").GetComponent<Button>().onClick.AddListener(delegate { PanelManager.Instance.CommonPanelManager.Hide_DisplaySetPanel(); });
        UIObject.transform.Find("HelpBtn").GetComponent<Button>().onClick.AddListener(delegate { PanelManager.Instance.CommonPanelManager.Hide_DisplayHelpPanel(); });
        UIObject.transform.Find("QuitBtn").GetComponent<Button>().onClick.AddListener(delegate {

            PanelManager.Instance.CommonPanelManager.Hide_DisplayQuitPanel();
            //for (int i = 0; i < 40; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Debug.Log(OutDoorMeasurementData.exportV_TableList[i][j]);
            //    }
            //}
           
        });  
    }

}

