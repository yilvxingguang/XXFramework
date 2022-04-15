using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDescriptionPanel : IPanel
{
    private Image image;
    private Text text;
    private Button hideButton;

    private Sprite sprite;
    private string str;

    public ImageDescriptionPanel() : base("ToolPanel/ImageDescriptionPanel", "UIObject")
    {
        image = UIObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        text = UIObject.transform.GetChild(0).GetComponentInChildren<Text>();
        hideButton = UIObject.transform.GetChild(0).GetComponentInChildren<Button>();
        hideButton.onClick.AddListener(() => { Hide_DisplayUI(false); });
    }

    public override void Hide_DisplayUI(bool isDisplay = false)
    {
        base.Hide_DisplayUI(isDisplay);
    }
    public void InitData(Sprite sprite, string text)
    {
        this.sprite = sprite;
        str = text;
    }
    protected override void UIAssignment()
    {
        base.UIAssignment();
        image.sprite = sprite;
        text.text = str;
    }
}
