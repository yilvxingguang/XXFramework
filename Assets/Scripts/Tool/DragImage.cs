using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 Screen = new Vector2(UnityEngine.Screen.width, UnityEngine.Screen.height);
    float nowWidth = 0;
    float nowHeight = 0;
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    /// <summary>
    /// 拖拽过程
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.position += new Vector3(Input.GetAxis("Mouse X") * 12, Input.GetAxis("Mouse Y") * 12, 0);
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("修正前图片坐标：" + transform.localPosition);
        ReChange();
        Debug.Log("修正后图片坐标：" + transform.localPosition);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnlargeAndMove();
        //ReChange();
    }
    /// <summary>
    /// 判断范围移动校正图片
    /// </summary>
    private void EnlargeAndMove()
    {
        if (transform.localScale.x > 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
                transform.localScale += new Vector3(Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Mouse ScrollWheel"), 0);
        }
        if (transform.localScale.x < 1)
        {
            transform.localScale = Vector3.one;
            transform.localPosition = Vector3.zero;
        }
        if (transform.localScale.x == 1 && transform.localScale.x == 1 && transform.localScale.x == 1)
        {
            transform.localPosition = Vector3.zero;
        }

    }
    /// <summary>
    /// 拖拽结束后根据坐标修改图片位置，防止超出屏幕
    /// </summary>
    private void ReChange()
    {
        if (transform.localScale.x > 1.01 && transform.localPosition != Vector3.zero)
        {
            nowWidth = transform.localScale.x * Screen.x;
            nowHeight = transform.localScale.y * Screen.y;
            Debug.Log("nowWidth:" + nowWidth + "nowHeight:" + nowHeight + "放大倍数X：" + transform.localScale.x + "放大倍数Y:" + transform.localScale.y);
            Vector3 R_up = new Vector3((nowWidth - Screen.x) / 2, (nowHeight - Screen.y) / 2, 0);
            Vector3 R_down = new Vector3((nowWidth - Screen.x) / 2, -(nowHeight - Screen.y) / 2, 0);
            Vector3 L_up = new Vector3(-(nowWidth - Screen.x) / 2, (nowHeight - Screen.y) / 2, 0);
            Vector3 L_down = new Vector3(-(nowWidth - Screen.x) / 2, -(nowHeight - Screen.y) / 2, 0);
            if (transform.localPosition.x > R_up.x || transform.localPosition.x < L_up.x || transform.localPosition.y > R_up.y || transform.localPosition.y < R_down.y)
            {
                Debug.Log("不在范围内");
                if (transform.localPosition.x > R_up.x && transform.localPosition.y > R_up.y)
                {
                    transform.localPosition = R_up;
                    Debug.Log("赋值后的坐标"+transform.localPosition);
                    return;
                }

                if (transform.localPosition.x > R_up.x && transform.localPosition.y < R_up.y)
                {
                    transform.localPosition = R_down;
                    return;
                }

                if (transform.localPosition.x < R_up.x && transform.localPosition.y > R_up.y)
                {
                    transform.localPosition = L_up;
                    return;
                }

                if (transform.localPosition.x < R_up.x && transform.localPosition.y < R_up.y)
                {
                    transform.localPosition = L_down;
                    return;
                }

            }
            Debug.Log("R_UP:" + R_up + "R_down:" + R_down + "L_up:" + L_up + "L_down:" + L_down);
        }
    }

}
