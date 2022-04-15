using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Arrow : MonoBehaviour
{
    public bool isFind = true;
    private Transform Player;
    private Vector3 targetPosition;

    private void Start()
    {
        Player = GameObject.Find("Player").transform;

        targetPosition = transform.Find("Target").position;

        //if (DrillManager.Instance.isIntelligence) isFind = true;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            isFind = true;
        }
        if (isFind)
            MovePlayer();
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        //if (HaspLock.Instance.IsGetInfo(HaspLock.Instance.Scope, HaspLock.Instance.VendorCode) == false)
        //{
        //    UIHandleSystem.Instance.CommonUISystem.Hide_DisplayMessagePanel("检测不到锁");
        //    return;
        //}

        //UIHandleSystem.Instance.DrillSceneUISystem.Hide_DisplayGoodsUI();
       
        //点击之后销毁箭头
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// 玩家寻找箭头
    /// </summary>
    private void MovePlayer()
    {
        Player.GetComponent<PlayerBehavior>().Move(targetPosition, 2f, transform.Find("LookAt"));

        //Debug.Log(Player.position);
        //Debug.Log(targetPosition);
        if (Vector3.Distance(Player.position, targetPosition) <= 0.1f)
        {
            isFind = false;

            //if (DrillManager.Instance.isIntelligence)
            //{
            //    Invoke("OnMouseDown", 1.5f);
            //}
        }
    }
}
