using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// IndoorScene 场景
/// </summary>
public class IndoorSceneState : ISceneState
{
    private Transform Play;
  
    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="name"></param>
    public IndoorSceneState() : base("IndoorScene")
    {
        //Debug.Log("111");
        //Debug.Log(OutDoorMeasurementData.exportD_TableList.Count);
        //Debug.Log(OutDoorMeasurementData.exportV_TableList.Count);
        //Debug.Log(OutDoorMeasurementData.exportWaterRluer_TableList.Count);
        //Debug.Log(StepPanel.exportV_TableRow);

        //Debug.Log(OutDoorMeasurementData.exportWaterRluer_TableList.Count);
    }

    public override void StateStart()
    {
        base.StateStart();
        
        Play = GameObject.Find("Player").transform;
        
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
       

    }
    public override void StateEnd()
    {
        base.StateEnd();
    }
    

    
}
