using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 提示弹出框（特殊）
/// </summary>
public class MessagePanel : IPanel
{
    Action MyAction;
    /// <summary>
    /// 提示信息
    /// </summary>
    string Messagetext;
    /// <summary>
    /// 构造
    /// </summary>
    public MessagePanel() : base("ToolPanel/MessagePanel", "UIObject")
    {
        UIObject.transform.GetChild(0).GetComponentInChildren<Button>().onClick.AddListener(delegate
        { /*Debug.Log(UIObject.transform.parent.name);*/
            Hide_DisplayUI();

            if (MyAction != null)
                MyAction.Invoke();

        });
    }
    /// <summary>
    /// 赋值
    /// </summary>
    /// <param name="text"></param>
    public void Init(string text, Action action)
    {
        Messagetext = text;
        MyAction = action;
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void UIAssignment()
    {
        UIObject.transform.GetChild(0).GetComponentInChildren<Text>().text = Messagetext;
        UIObject.transform.SetAsLastSibling();
    }
}
