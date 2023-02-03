using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class AnimationDestory : MonoBehaviour
//{

//    private Vector3 targetPosition;

//    private GameObject player;
//    private bool isLerp = true;

//    private Animation mAnimation;
//    private AnimationClip mClip;
//    private AnimationEvent mEvent;

//    private AudioSource audioSource;

//    private GameObject Terrains; //地形父物体
//    private GameObject GoodsObject; //工具物体

//    private bool isAdvance = false;  //是否提前发生地形变化
//    private bool isDisplay = true;  //是否去显示 箭头（处理音配和动画）

//    private int goodsIndex;
//    TerrainHandleSystem terrainHandleSystem = TerrainHandleSystem.Instance;
//    DrillSceneData drillSceneData = DrillSceneData.Instance;

//    private void Start()
//    {
//        goodsIndex = drillSceneData.GoodsIndex;

//        Terrains = terrainHandleSystem.GoodsTerrainHandle.TerrainParent;
//        Debug.Log(drillSceneData.GoodsName);
//        GoodsObject = terrainHandleSystem.BuildTerrainHandle.TerrainParent.transform.Find(drillSceneData.GoodsName).gameObject;

//        player = GameObject.Find("Player");

//        targetPosition = GoodsObject.transform.position;

//        mAnimation = GetComponentInChildren<Animation>();

//        //播放音乐
//        audioSource = GameObject.Find("LoopProject").GetComponent<AudioSource>();
//        audioSource.clip = FactoryManager.assetFactory.LoadAudioClip(drillSceneData.BuildName + "/" +
//             (drillSceneData.StepIndex + 1) + "_" + (drillSceneData.GoodsIndex + 1));
//        audioSource.Play();


//        if (mAnimation == null)
//        {
//            Invoke("DestoryObject", 2f);
//        }
//        else
//        {
//            mAnimation.playAutomatically = false;
//            mClip = mAnimation.clip;
//            if (mClip.events.Length == 0)
//            {
//                mEvent = new AnimationEvent();
//                mEvent.time = mClip.length - 0.1f;
//                mEvent.functionName = "DestoryObject";
//                mClip.AddEvent(mEvent);
//            }
//        }


//        Special();
//        if (isAdvance)
//        {
//            HandleSystem.Instance.UpdateGoods(goodsIndex, false);
//        }
//        Debug.Log(goodsIndex);
//    }
//    private void Update()
//    {
//        if (isLerp)
//            CameraMove();

//        if (isDisplay == false && audioSource.isPlaying == false)
//            ChangeHandle();
//    }
//    /// <summary>
//    /// 相机Lerp移动
//    /// </summary>
//    private void CameraMove()
//    {
//        if (Vector3.Distance(player.transform.position, targetPosition) >= player.GetComponent<PlayerBehavior>().distanceTaget)
//        {
//            player.GetComponent<PlayerBehavior>().Move(targetPosition, 2f, GoodsObject.transform.GetChild(0));
//        }
//        else
//        {
//            if (GoodsObject.name == "TotalStation")
//            {
//                player.transform.position = targetPosition;
//                player.transform.LookAt(GoodsObject.transform.Find("_TotalStation/TotalStation/Prism/Prism"));
//            }
//            isLerp = false;
//            Debug.Log("开始播放动画 ");
//            mAnimation.Play();
//        }
//    }

//    public void DestoryObject()
//    {
//        if (audioSource.isPlaying == false)
//        {
//            isDisplay = true;
//        }
//        else
//        {
//            GoodsObject.transform.position = new Vector3(0, 10000, 0);
//            isDisplay = false;
//        }
//        ChangeHandle();
//    }

//    private void OnDestroy()
//    {
//        if (mAnimation != null) mClip.events = null;

//        if (audioSource.isPlaying) audioSource.Stop();
//    }
//    /// <summary>
//    /// 变化处理
//    /// </summary>
//    private void ChangeHandle()
//    {
//        TerrainHandleSystem terrainHandleSystem = TerrainHandleSystem.Instance;
//        if (audioSource.isPlaying == false)
//        {
//            if (isDisplay && isAdvance == false)
//            {

//                HandleSystem.Instance.UpdateGoods(goodsIndex, false);
//                HandleSystem.Instance.UpdateGoodsArrow(goodsIndex + 1, false);

//            }
//            else
//            {
//                HandleSystem.Instance.UpdateGoodsArrow(goodsIndex + 1, false);

//            }
//            GameObject.Destroy(GoodsObject);
//        }
//        else
//        {
//            if (isAdvance == false)
//                HandleSystem.Instance.UpdateGoods(goodsIndex, false);
//        }
//    }

//    /// <summary>
//    /// 步骤选择按钮的更新
//    /// </summary>
//    private void UpdateGoodsSelectButton()
//    {
//        //更新步骤选择按钮
//        if (GameObject.Find("Canvas").transform.Find("GoodsSelectPanel").gameObject.activeSelf)
//        {
//            Transform GoodsButtons = GameObject.Find("Canvas").transform.Find("GoodsSelectPanel").Find("GoodsButtons");
//            foreach (Transform item in GoodsButtons)
//            {
//                item.GetComponent<Button>().interactable = true;
//            }
//            GoodsButtons.GetChild(drillSceneData.GoodsIndex).GetComponent<Button>().interactable = false;
//        }
//    }

//    /// <summary>
//    /// 处理特殊情况
//    /// </summary>
//    private void Special()
//    {
//        List<string> stepIndex = null;
//        switch (TerrainHandleSystem.Instance.BuildTerrainHandle.BuildName)
//        {
//            case "WaterGrate":
//                stepIndex = new List<string>() { "0_6", "1_7", "2_11" };
//                break;
//            case "PumpStation":
//                stepIndex = new List<string>() { "0_4", "1_6", "2_8", "3_7" };
//                break;
//            case "Culvert":
//                stepIndex = new List<string>() { "1_7" };
//                break;
//            case "Aqueduct":
//                stepIndex = new List<string>() { "1_3", "2_2", "3_5", "3_7" };
//                break;
//            case "GravityDam":
//                stepIndex = new List<string>() { "1_7" };
//                break;
//            case "RockfillDam":
//                stepIndex = new List<string>() { "0_1", "1_1" };
//                break;
//            case "ModernPavilion":
//                stepIndex = new List<string>() { "0_8", "1_7", "2_8" };
//                break;

//            default:
//                break;
//        }
//        if (stepIndex != null)
//        {
//            foreach (var item in stepIndex)
//            {
//                if (item == drillSceneData.StepIndex.ToString() + "_" + drillSceneData.GoodsIndex.ToString())
//                    isAdvance = true;
//            }
//        }

//        string BuildName = drillSceneData.BuildName;
//        if (BuildName == "FlowerBasin")
//        {
//            if (drillSceneData.StepIndex == 0)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//            if (drillSceneData.StepIndex == 2)
//            {
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//            if (drillSceneData.StepIndex == 3)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//        }
//        if (BuildName == "FlowerBasinChange")
//        {
//            if (drillSceneData.StepIndex == 0)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//            if (drillSceneData.StepIndex == 1)
//            {
//                 if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//            if (drillSceneData.StepIndex == 2)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//        }
//        if (BuildName == "LeafCuttingPropagation")
//        {
//            if (drillSceneData.StepIndex == 1)
//            {
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
              
//            }
//            if (drillSceneData.StepIndex == 2)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//        }
//        if (BuildName == "DivisionPropagation")
//        {
//            if (drillSceneData.StepIndex == 0)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 4)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//            if (drillSceneData.StepIndex == 1)
//            {
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 6)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//        }
//        if (BuildName == "LayeringPropagation")
//        {
//            if (drillSceneData.StepIndex == 0)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 6)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 7)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//            if (drillSceneData.StepIndex == 1)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 6)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//            if (drillSceneData.StepIndex == 2)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 4)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//            if (drillSceneData.StepIndex == 3)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 7)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//        }
//        if (BuildName == "SoftwoodCutting")
//        { 
//            if (drillSceneData.StepIndex == 1)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 4)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//            if (drillSceneData.StepIndex == 2)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//        }
//        if (BuildName == "SowingOfThyme")
//        {
//            if (drillSceneData.StepIndex == 0)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//            if (drillSceneData.StepIndex == 1)
//            {
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//            if (drillSceneData.StepIndex == 2)
//            {
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//            if (drillSceneData.StepIndex == 3)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//        }
//        if (BuildName == "BranchingAndBudding")
//        {
//            if (drillSceneData.StepIndex == 0)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 4)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//            if (drillSceneData.StepIndex == 1)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 4)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//        }

//        if (BuildName == "FlowerArranging")
//        {
//            if (drillSceneData.StepIndex == 0)
//            {
//                if (drillSceneData.GoodsIndex == 0)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
//            if (drillSceneData.StepIndex == 1)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 3)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 5)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);

//            }
//            if (drillSceneData.StepIndex == 2)
//            {
//                if (drillSceneData.GoodsIndex == 1)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//                if (drillSceneData.GoodsIndex == 2)
//                    GameObject.Destroy(terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.GetChild(0).Find("False").gameObject);
//            }
            
//        }
//    }


//}