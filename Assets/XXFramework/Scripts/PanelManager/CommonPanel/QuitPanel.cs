using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 结束面板
/// </summary>
public class QuitPanel : IPanel
{    
    /// <summary>
    /// 构造
    /// </summary>
    public QuitPanel() : base("CommonPanel/QuitPanel", "UIObject")
    {
        UIObject.transform.GetChild(0).Find("QuitButton").GetComponent<Button>().onClick.AddListener(delegate { Application.Quit(); });
        UIObject.transform.GetChild(0).Find("CancleButton").GetComponent<Button>().onClick.AddListener(delegate { Hide_DisplayUI(); });
    }
}

