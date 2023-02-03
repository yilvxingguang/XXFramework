using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : IPanel
{

    private string[] Question;
    private int questionIndex = 0;


    private Text QuestionText;
    private Text AnswerText;
    private GameObject Toggle;

    /// <summary>
    /// 完成继续按钮
    /// </summary>
    private Button GoonButton;
    /// <summary>
    /// 构造
    /// </summary>
    public QuestionPanel() : base("ToolPanel/QuestionPanel", "UIObject")
    {
        GoonButton = UIObject.transform.GetChild(0).Find("GoonButton").GetComponent<Button>();
        GoonButton.onClick.AddListener(GoonButtonEvent);

        QuestionText = UIObject.transform.GetChild(0).Find("Question/QuestionText/Viewport/QuestionText").GetComponent<Text>();
        AnswerText = UIObject.transform.GetChild(0).Find("Question/AnswerText").GetComponent<Text>();
        AnswerText.gameObject.SetActive(false);
        Toggle = UIObject.transform.GetChild(0).Find("Question/Option").gameObject;
        foreach (Toggle item in Toggle.GetComponentsInChildren<Toggle>())
        {
            item.onValueChanged.AddListener(delegate { ToggleClick(true); });
        }
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void UIAssignment()
    {
        base.UIAssignment();
        QuestionInit();
    }

    public void Init(List<string> question)
    {
        Question = new string[question.Count];
        for (int i = 0; i < Question.Length; i++)
        {
            Question[i] = question[i];
        }
        questionIndex = 0;
    }

    /// <summary>
    /// 按钮事件
    /// </summary>
    void GoonButtonEvent()
    {

        if (questionIndex < Question.Length - 1)
        {
            questionIndex++;
            QuestionInit();
            return;
        }
        Hide_DisplayUI();
    }

    private void QuestionInit()
    {
        Toggle.GetComponent<ToggleGroup>().SetAllTogglesOff();
        ToggleClick(false);
        Debug.Log(Question[questionIndex]);
        string[] quest = Question[questionIndex].Split(new string[] { "A：","B：","C：","D：","答案：" }, StringSplitOptions.RemoveEmptyEntries);

        QuestionText.text = quest[0];
        Toggle.GetComponentsInChildren<Text>()[0].text = "A:"+quest[1];
        Toggle.GetComponentsInChildren<Text>()[1].text = "B:"+quest[2];
        Toggle.GetComponentsInChildren<Text>()[2].text = "C:"+ quest[3];


        if(quest.Length<6)
        {
            Toggle.GetComponentsInChildren<Text>()[3].transform.parent.gameObject.SetActive(false);
            AnswerText.text ="答案："+ quest[4];
        }
        else
        {
            Toggle.transform.GetChild(3).gameObject.SetActive(true);
            Toggle.GetComponentsInChildren<Text>()[3].text = "D:"+quest[4];
            AnswerText.text = "答案："+quest[5];
        }

        




    }


    private void ToggleClick(bool isSelect)
    {
        foreach (Toggle item in Toggle.GetComponentsInChildren<Toggle>())
        {
            item.interactable = !isSelect;
        }
        AnswerText.gameObject.SetActive(isSelect);
    }
}

