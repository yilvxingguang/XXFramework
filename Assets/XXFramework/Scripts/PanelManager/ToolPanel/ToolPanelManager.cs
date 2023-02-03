using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ToolPanelManager : IPanelManager
{

    private MessagePanel messagePanel;
    /// <summary>
    /// 提示面板
    /// </summary>
    public MessagePanel MessagePanel
    {
        get { return messagePanel ?? (messagePanel = new MessagePanel()); }
    }
    /// <summary>
    /// 显示提示面板
    /// </summary>
    /// <param name="messageText"></param>
    /// <param name="display"></param>
    public void Hide_DisplayMessagePanel(string messageText, Action action = null, bool display = true)
    {
        MessagePanel.Init(messageText, action);
        MessagePanel.Hide_DisplayUI(display);
    }



    private QuestionPanel questionPanel;
    /// <summary>
    ///问题面板
    /// </summary>
    public QuestionPanel QuestionPanel
    {
        get { return questionPanel ?? (questionPanel = new QuestionPanel()); }
    }
    /// <summary>
    /// 显示问题面板
    /// </summary>
    /// <param name="question"></param>
    /// <param name="display"></param>
    public void Hide_DisplayQuestionPanel(List<string> question, bool display = true)
    {
        QuestionPanel.Init(question);
        QuestionPanel.Hide_DisplayUI(display);
    }

    /// <summary>
    /// 图片描述面板
    /// </summary>
    private ImageDescriptionPanel imageDescriptionPanel;

    public ImageDescriptionPanel ImageDescriptionPanel
    {
        get { return imageDescriptionPanel ?? (imageDescriptionPanel = new ImageDescriptionPanel()); }
    }
    /// <summary>
    /// 显示图片描述面板
    /// </summary>
    /// <param name="sprite">图片</param>
    /// <param name="str">描述</param>
    /// <param name="display"></param>
    public void Hide_DisplayImageDescriptionPanel(Sprite sprite, string str, bool display = true)
    {
        ImageDescriptionPanel.InitData(sprite, str);
        ImageDescriptionPanel.Hide_DisplayUI(display);
    }
    public void Clear()
    {
        messagePanel = null;
        questionPanel = null;
        imageDescriptionPanel = null;
    }
}

