using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;



public class MainSceneUIManager : MonoBehaviour
{
    private GameObject panelBookTask, TxtsOrTips, panelStepsGeneralization, panelStepsDetail;
    private Button btnTaskBook, btnReceive, btnRecoveryStep;
    private Text txtName, txtProjectDescription, txtTaskContent, txtTaskSteps;//任务书的各个txt
    private Text[] txtGeneralizationSteps;
  //  public static int HallBtnSIndex;
    public static string HallBtnSName = "BtnFlowerBasin";
    public Font font;

    void Start()
    {
        panelBookTask = transform.Find("PanelBookTask").gameObject;
        panelBookTask.SetActive(false);

        btnTaskBook = transform.Find("BtnTaskbook").GetComponent<Button>();
        btnTaskBook.onClick.AddListener(delegate ()
        {
            panelBookTask.SetActive(true);
        });
        btnReceive = panelBookTask.transform.Find("BtnReceive").GetComponent<Button>();
        btnReceive.onClick.AddListener(delegate ()
        {
            panelBookTask.SetActive(false);
        });

        panelStepsGeneralization = transform.Find("StepsManager/PanelStepsGeneralization").gameObject;
        panelStepsGeneralization.SetActive(false);
        btnRecoveryStep = transform.Find("StepsManager/BtnRecoveryStep").GetComponent<Button>();
        btnRecoveryStep.GetComponentInChildren<Text>().text = "展开步骤";
        btnRecoveryStep.onClick.AddListener(delegate ()
        {
            if (panelStepsGeneralization.activeInHierarchy)
            {
                btnRecoveryStep.GetComponentInChildren<Text>().text="展开步骤";
                panelStepsGeneralization.SetActive(false);
            }
            else
            {
                btnRecoveryStep.GetComponentInChildren<Text>().text = "收回步骤";
                panelStepsGeneralization.SetActive(true);
            }
        });
        ////根据大厅场景点击不同的按钮，加载相应的物体
        //GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/" + HallBtnSName.Substring(3)) as GameObject);
        //Debug.Log(go.name);

        ////    StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAssets/MainSceneTxtData.json");//读取数据，转换成数据流
        //StreamReader streamreader = new StreamReader(Application.dataPath + "/StreamingAssets/Json/"+HallBtnSName.Substring(3)+".json");//读取数据，转换成数据流
        //JsonReader js = new JsonReader(streamreader);//再转换成json数据
        //Root r = JsonMapper.ToObject<Root>(js);//读取
        ////任务书上的各个文本读取
        //TxtsOrTips = panelBookTask.transform.Find("TxtsOrTips").gameObject;
        //txtName = TxtsOrTips.transform.Find("TxtName").GetComponent<Text>();
        //txtName.text = r.MainSceneTxtData.TaskBook.ChineseName;
        //txtProjectDescription = TxtsOrTips.transform.Find("TxtProjectDescription").GetComponent<Text>();
        //txtProjectDescription.text = r.MainSceneTxtData.TaskBook.ProjectDescription;
        //txtTaskContent = TxtsOrTips.transform.Find("TxtTaskContent").GetComponent<Text>();
        //txtTaskContent.text = r.MainSceneTxtData.TaskBook.TaskContent;
        //txtTaskSteps = TxtsOrTips.transform.Find("TxtTaskSteps").GetComponent<Text>();
        //txtTaskSteps.text = r.MainSceneTxtData.TaskBook.TaskSteps;
        //TxtsOrTips.AddComponent<VerticalLayoutGroup>();
        //for (int i = 0; i < TxtsOrTips.transform.childCount; i++)
        //{
        //    if (TxtsOrTips.transform.GetChild(i).gameObject.GetComponent<ContentSizeFitter>() != null)
        //    {
        //        //   TxtsOrTips.transform.GetChild(i).gameObject.GetComponent<ContentSizeFitter>().enabled = false;
        //        Destroy(TxtsOrTips.transform.GetChild(i).gameObject.GetComponent<ContentSizeFitter>());
        //    }
        //}

        ////简略步骤
        //int txtGeneralizationStepsCount = r.MainSceneTxtData.StepsGeneralization.Count;
        //txtGeneralizationSteps = new Text[txtGeneralizationStepsCount];

        ////GameObject btn = new GameObject("Btn", typeof(Button), typeof(RectTransform), typeof(Image));  //创建一个GameObject 加入Button组件
        ////btn.transform.SetParent(panelStepsGeneralization.transform);
        ////Button _btn = btn.GetComponent<Button>();   //获得Button的Button组件

        //for (int i = 0; i < r.MainSceneTxtData.StepsGeneralization.Count; i++)
        //{
        //    GameObject button = new GameObject("BtnGeneralization" + i, typeof(Button), typeof(RectTransform), typeof(Image));  //创建一个GameObject 加入Button组件
        //    button.transform.SetParent(panelStepsGeneralization.transform);
        //    Button _btnGeneralization = button.GetComponent<Button>();   //获得Button的Button组件
        //    int _i = i;
        //    Text txtGeneralizationStep = new GameObject("txtGeneralizationStep" + i).AddComponent<Text>();
        //    txtGeneralizationStep.transform.SetParent(_btnGeneralization.transform);
        //    txtGeneralizationSteps[i] = txtGeneralizationStep.GetComponent<Text>();
        //    txtGeneralizationSteps[i].font = font;
        //    txtGeneralizationSteps[i].fontSize = 30;
        //    txtGeneralizationSteps[i].color = Color.black;
        //    txtGeneralizationSteps[i].transform.localPosition = Vector3.zero;
        //    txtGeneralizationSteps[i].text = r.MainSceneTxtData.StepsGeneralization[i].TxtStepsGeneralizationChinese;
        //    txtGeneralizationStep.gameObject.AddComponent<ContentSizeFitter>();
        //    txtGeneralizationStep.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        //    txtGeneralizationStep.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        //    //详细步骤
        //    panelStepsDetail = transform.Find("StepsManager/PanelStepsDetail").gameObject;
        //    Text txtToolName = panelStepsDetail.transform.Find("TxtTool").GetComponent<Text>();
        //    Text TxtStepDescribe = panelStepsDetail.transform.Find("TxtStepDescribe").GetComponent<Text>();
        //    Text TxtTip = panelStepsDetail.transform.Find("TxtTip").GetComponent<Text>();
        //    int stepsDetailIndex = 0;
        //    txtToolName.text = r.MainSceneTxtData.StepsGeneralization[0].StepsDetail[0].ToolChineseName;
        //    TxtStepDescribe.text = r.MainSceneTxtData.StepsGeneralization[0].StepsDetail[0].TxtStepsDetail;
        //    if (r.MainSceneTxtData.StepsGeneralization[0].StepsDetail[0].TxtTip != null)
        //    {
        //        if (TxtTip.gameObject.activeInHierarchy == false)
        //            TxtTip.gameObject.SetActive(true);
        //        TxtTip.text = r.MainSceneTxtData.StepsGeneralization[0].StepsDetail[0].TxtTip;
        //    }
        //    else
        //    {
        //        TxtTip.gameObject.SetActive(false);
        //    }
        //    _btnGeneralization.onClick.AddListener(delegate ()
        //    {
        //        if(r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[0].ToolChineseName !=null)
        //        {
        //            txtToolName.text = r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[0].ToolChineseName;
        //            TxtStepDescribe.text = r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[0].TxtStepsDetail;
        //        }
        //        if(r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[0].TxtTip != null)
        //        {
        //            if(TxtTip.gameObject.activeInHierarchy==false)
        //                TxtTip.gameObject.SetActive(true);
        //            TxtTip.text = r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[0].TxtTip;
        //        }
        //        else
        //        {
        //            TxtTip.gameObject.SetActive(false);
        //        }
        //    });

        //    Image imageTool = panelStepsDetail.transform.Find("ImageTool").GetComponent<Image>();
        //    imageTool.GetComponent<Button>().onClick.AddListener(delegate ()
        //    {
        //        stepsDetailIndex++;
        //        Debug.Log(_i + "--------"+stepsDetailIndex);
                
        //        //if (r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[stepsDetailIndex].ToolName != null)
        //        //{
        //        //    txtToolName.text = r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[stepsDetailIndex].ToolName;
        //        //    TxtStepDescribe.text = r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[stepsDetailIndex].TxtStepsDetail;
        //        //}
        //        //if (r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[stepsDetailIndex].TxtTip != null)
        //        //{
        //        //    if (TxtTip.gameObject.activeInHierarchy == false)
        //        //        TxtTip.gameObject.SetActive(true);
        //        //    TxtTip.text = r.MainSceneTxtData.StepsGeneralization[_i].StepsDetail[stepsDetailIndex].TxtTip;
        //        //}
        //        //else
        //        //{
        //        //    TxtTip.gameObject.SetActive(false);
        //        //}
        //    });

        //}
        //panelStepsGeneralization.AddComponent<VerticalLayoutGroup>();

    }

}

