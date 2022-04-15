using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
/// <summary>
/// Common UI管理
/// </summary>
public class CommonPanelManager:IPanelManager
{
    private TotalPanel totalPanel;
    /// <summary>
    /// 标头面板
    /// </summary>
    public TotalPanel TotalPanel
    {
        get { return totalPanel; }
    }
    /// <summary>
    /// 显示标头面板
    /// </summary>
    /// <param name="display"></param>
    /// <param name="isActiveBack"></param>
    /// <param name="backSceneState"></param>
    public void Hide_DisplayTotalPanel(bool display = true, bool isActiveBack = false, ISceneState backSceneState = null)
    {
        if (totalPanel == null)
            totalPanel = new TotalPanel(isActiveBack);
        TotalPanel.Hide_DisplayUI(display);
        TotalPanel.SetBackScene(backSceneState);
    }


    private HelpPanel helpPanel;
    /// <summary>
    /// 帮助面板
    /// </summary>
    public HelpPanel HelpPanel
    {
        get { return helpPanel ?? (helpPanel = new HelpPanel()); }
    }
    /// <summary>
    /// 显示帮助面板
    /// </summary>
    /// <param name="display"></param>
    public void Hide_DisplayHelpPanel(bool display = true)
    {
        HelpPanel.Hide_DisplayUI(display);
    }



    private SetPanel setPanel;
    /// <summary>
    /// 设置面板UI
    /// </summary>
    public SetPanel SetPanel
    {
        get { return setPanel ?? (setPanel = new SetPanel()); }
    }
    /// <summary>
    /// 显示设置面板
    /// </summary>
    /// <param name="display"></param>
    public void Hide_DisplaySetPanel(bool display = true)
    {
        SetPanel.Hide_DisplayUI(display);
    }



    private QuitPanel quitPanel;
    /// <summary>
    /// 结束面板
    /// </summary>
    public QuitPanel QuitPanel
    {
        get { return quitPanel ?? (quitPanel = new QuitPanel()); }
    }

    /// <summary>
    /// 显示结束面板
    /// </summary>
    /// <param name="display"></param>
    public void Hide_DisplayQuitPanel(bool display = true)
    {
        QuitPanel.Hide_DisplayUI(display);
    }



    public void Clear()
    {
        totalPanel = null;
        helpPanel = null;
        setPanel = null;
        quitPanel = null;
        
    }
}

