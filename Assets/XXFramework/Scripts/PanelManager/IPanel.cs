using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 面板基类
/// </summary>
public class IPanel
{
    /// <summary>
    /// canvas
    /// </summary>
    private Transform canvas;
    /// <summary>
    /// Canvas  （CanvasUI）
    /// </summary>
    public Transform Canvas
    {
        get { return canvas ?? (canvas = GameObject.Find("CanvasUI").transform);}
    }

    protected GameObject uiObject;
    /// <summary>
    /// UIPanel
    /// </summary>
    public GameObject UIObject
    {
        get { return uiObject ?? (uiObject = CreateUI()); }
    }

    /// <summary>
    /// UIPanel父物体
    /// </summary>
    public Transform ParentUI;
    /// <summary>
    /// UIPanel，名字
    /// </summary>
    protected string UIName;


    /// <summary>
    /// 构造 初始化
    /// </summary>
    /// <param name="name">UIPanel名字</param>
    /// <param name="parentUIName">UIpanel父物体名字</param>
    public IPanel(string name,string parentUIName)
    {
        if (parentUIName == null)
        {
            ParentUI = Canvas;
        }
        else
        {
            ParentUI = Canvas.Find(parentUIName);
        }
        UIName = name;
        CreateUI();//实例化UI
    }
    /// <summary>
    /// 创建UI物体
    /// </summary>
    /// <returns></returns>
    private GameObject CreateUI()
    {
        try
        {
            uiObject = Canvas.Find(UIName).gameObject;
        }
        catch (Exception)
        {
            uiObject = GameObject.Instantiate(AssetManager.Instance.ResourceAsset.LoadPanelObject(UIName), Canvas);
            uiObject.name = UIName;
        }
        return uiObject;
    }
    /// <summary>
    /// 控制UI的显示隐藏(默认隐藏)
    /// </summary>
    /// <param name="isDisplay">是否显示</param>
    /// <param name="data">数据</param>
    public virtual void Hide_DisplayUI(bool isDisplay = false)
    {
        UIObject.SetActive(isDisplay);
        if (isDisplay) UIAssignment();
    }
    /// <summary>
    /// 删除UI
    /// </summary>
    public void DeleteUI()
    {
        GameObject.Destroy(UIObject);
        uiObject = null;
    }
    /// <summary>
    /// UI赋值
    /// </summary>
    /// <param name="data">传递数据</param>
    protected virtual void UIAssignment()
    {

    }
}

