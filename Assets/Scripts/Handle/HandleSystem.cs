using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
/// <summary>
/// 核心处理
/// </summary>
//public class HandleSystem : Singleton<HandleSystem>
//{
//    TerrainHandleSystem terrainHandleSystem = TerrainHandleSystem.Instance;
//    UIHandleSystem uiHandleSystem = UIHandleSystem.Instance;
//    DrillSceneData drillSceneData = DrillSceneData.Instance;
//    /// <summary>
//    /// 更新建筑
//    /// </summary>
//    /// <param name="buildname"></param>
//    public void UpdateBuild(string buildname)
//    {
//        //更新数据  
//        drillSceneData.UpdataBuild(buildname);
//        //更新地形
//        terrainHandleSystem.UpdateBuildTerrain(drillSceneData.BuildName);
//        //更新步骤
//        UpdateStep(0);
//        uiHandleSystem.DrillSceneUISystem.Hide_DisplayTaskBookUI();
        
//    }
//    /// <summary>
//    /// 更新步骤
//    /// </summary>
//    /// <param name="stepIndex"></param>
//    public void UpdateStep(int stepIndex)
//    {
//        //删除工具
//        DeleteGoods();
//        //更新数据
//        drillSceneData.UpdataStep(stepIndex);
//        //更新地形
//        terrainHandleSystem.UpdateStepTerrain(drillSceneData.StepName, drillSceneData.StepIndex+1);
//        //调整步骤嘻嘻
//        InitStep();
//        //更新介绍面板
//        if(drillSceneData.isJustComeDrillScene)
//        {
//            //任务书显示
//            uiHandleSystem.DrillSceneUISystem.Hide_DisplayTaskBookUI();
//        }
//        else
//        {
//            uiHandleSystem.DrillSceneUISystem.Hide_DisplayIntroduceUI();
//        }      

//    }
//    /// <summary>
//    /// 更新工具
//    /// </summary>
//    /// <param name="goodsIndex"></param>
//    /// <param name="isChoice">是否为选择方式</param>
//    public void UpdateGoods(int goodsIndex, bool isChoice)
//    {
//        if (isChoice)
//        {
            
//            if (goodsIndex < 1)
//            {
//                //更新数据
//                drillSceneData.UpdataStep(drillSceneData.StepIndex);
//                Debug.Log(drillSceneData.StepName);
//                //更新地形
//                terrainHandleSystem.UpdateStepTerrain(drillSceneData.StepName, drillSceneData.StepIndex+1);
//                //调整步骤
//                InitStep();
//                return;
//            }
//            //更新地形
//            terrainHandleSystem.UpdateGoodsTerrain(goodsIndex - 1, drillSceneData.GoodsArray[goodsIndex - 1].Name);

//        }
//        else
//        {
//            if (goodsIndex > drillSceneData.GoodsArray.Length - 1) return;
//            //更新地形
//           terrainHandleSystem.UpdateGoodsTerrain(goodsIndex, drillSceneData.GoodsArray[goodsIndex].Name);
//        }
//    }
//    /// <summary>
//    /// 更新箭头的显示
//    /// </summary>
//    public void UpdateGoodsArrow(int goodsIndex, bool isChoice)
//    {


//        if (!isChoice)
//        {
//            if (goodsIndex > drillSceneData.GoodsArray.Length - 1)
//            {
//                uiHandleSystem.DrillSceneUISystem.Hide_DisplayFinishUI();
//                return;
//            }
//        }
//        //隐藏箭头
//        Transform Arrows = terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.parent.Find("Arrows");
//        foreach (Transform item in Arrows)
//        {
//            if (item.gameObject.activeSelf) item.gameObject.SetActive(false);
//        }
//        drillSceneData.UpdataGoods(goodsIndex);
//        //显示箭头
//        GameObject arrow = Arrows.transform.GetChild(goodsIndex).gameObject;
//        arrow.SetActive(true);
//        //更新控制台
//        UIHandleSystem.Instance.DrillSceneUISystem.ConsoleUpdateStepOrGoods(goodsIndex, arrow.GetComponent<Arrow>());
      

//    }
//    /// <summary>
//    /// 删除工具（主要用于正在播放工具动画，突然切换步骤）
//    /// </summary>
//    public void DeleteGoods()
//    {
//        if (drillSceneData.GoodsName == null)
//        {
//            return;
//        }
//        GameObject goods;
//        try
//        {
//            goods = terrainHandleSystem.BuildTerrainHandle.TerrainParent.transform.Find(drillSceneData.GoodsName).gameObject;
//        }
//        catch (Exception)
//        {
//            return;
//        }
//        GameObject.Destroy(goods);
//    }
//    /// <summary>
//    /// 步骤变化的更新
//    /// </summary>
//    private void InitStep()
//    {
//        //确定形式
//        DetermineSign();
//        //地形下箭头赋值
//        Transform arrows = terrainHandleSystem.GoodsTerrainHandle.TerrainParent.transform.parent.Find("Arrows");

//        for (int i = 0; i < arrows.transform.childCount; i++)
//        {
//            arrows.transform.GetChild(i).gameObject.name = drillSceneData.GoodsArray[i].Name;

//            Transform sign = arrows.transform.GetChild(i).GetComponentInChildren<Animation>().transform;
//            sign.LookAt(arrows.transform.GetChild(i).Find("Target"));
//        }
//        ////调试镜头
//        Transform player = GameObject.Find("Player").transform;
//        player.transform.SetPositionAndRotation(arrows.parent.transform.Find("TerrainStatic").position, arrows.parent.transform.Find("TerrainStatic").rotation);
//        Debug.Log(arrows.parent.transform.Find("TerrainStatic").position);
//        player.GetComponent<Camera>().fieldOfView = 80;


//        //更新控制台
//        UIHandleSystem.Instance.DrillSceneUISystem.ConsoleUpdateStepOrGoods(drillSceneData.StepIndex, arrows.GetChild(0).GetComponent<Arrow>(), false);
//    }
//    /// <summary>
//    /// 确定标志
//    /// </summary>
//    private void DetermineSign()
//    {
//        SignType drillSignType = DrillManager.Instance.DrillSignType;
//        foreach (Transform item in TerrainHandleSystem.Instance.StepTerrainHandle.Terrain.transform.Find("Arrows"))
//        {
//            Transform sign = item.GetComponentInChildren<Animation>().transform;

//            //if (sign.GetComponent<MeshFilter>().mesh == FactoryManager.assetFactory.LoadMesh(drillSignType.ToString()))
//            //{
//            //    return;
//            //}
//            //sign.GetComponent<MeshFilter>().mesh = FactoryManager.assetFactory.LoadMesh(drillSignType.ToString());
//            //sign.GetComponent<MeshRenderer>().sharedMaterial = FactoryManager.assetFactory.LoadMaterials(drillSignType.ToString());
//        }

//    }
//    /// <summary>
//    /// 清理DrillScene数据
//    /// </summary>
//    public void ClearEndDrillScene()
//    {
//        DeleteGoods();
//        drillSceneData.ClearEnd();
//        terrainHandleSystem.ClearEnd();
//        uiHandleSystem.ClearEndDrillSceneUI();
//    }

//    /// <summary>
//    /// 清除MainScene数据
//    /// </summary>
//    public void ClearEndMainScene()
//    {
//        uiHandleSystem.ClearEndMainSceneUI();
//    }

//}

