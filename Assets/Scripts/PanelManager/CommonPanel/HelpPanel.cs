using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 帮助面板
/// </summary>
public class HelpPanel : IPanel
{   
    /// <summary>
    /// 构造
    /// </summary>
    public HelpPanel() : base("CommonPanel/HelpPanel", "UIObject")
    {
        UIObject.transform.GetChild(0).transform.Find("BottomButton").GetComponent<Button>().onClick.AddListener(
         delegate
            {
                Hide_DisplayUI();
            });
    }
}

