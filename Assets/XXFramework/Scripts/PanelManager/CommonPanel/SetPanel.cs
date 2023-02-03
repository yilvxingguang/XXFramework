using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 设置面板
/// </summary>
public class SetPanel : IPanel
{
  
    /// <summary>
    /// 构造
    /// </summary>
    public SetPanel() : base("CommonPanel/SetPanel", "UIObject")
    {
        UIObject.transform.GetChild(0).transform.Find("BottomButton").GetComponent<Button>().onClick.AddListener(
         delegate
         {
             Hide_DisplayUI();
         });
    }
    protected override void UIAssignment()
    {
        base.UIAssignment();
    }
}

