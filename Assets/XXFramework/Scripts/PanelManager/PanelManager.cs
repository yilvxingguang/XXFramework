using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 面板管理
/// </summary>
public class PanelManager
{
    private static PanelManager instance;
    public static PanelManager Instance
    {
        get { return instance ?? (instance = new PanelManager()); }
    }
    private CommonPanelManager commonPanelManager;
    /// <summary>
    /// CommomPanel管理
    /// </summary>
    public CommonPanelManager CommonPanelManager
    {
        get { return commonPanelManager ?? (commonPanelManager = new CommonPanelManager()); }
    }

    private ToolPanelManager toolPanelManager;
    /// <summary>
    /// ToolPanel管理
    /// </summary>
    public ToolPanelManager ToolPanelManager
    {
        get { return toolPanelManager ?? (toolPanelManager = new ToolPanelManager()); }
    }

    public void Clear(IPanelManager panelmanager)
    {
        panelmanager.Clear();
       
        CommonPanelManager.Clear();
        ToolPanelManager.Clear();
       
    }



}

