using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 修改Operate子节点的标签显示
/// </summary>
public class TagDisplay : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.pointerEnter.transform.GetChild(0).gameObject.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        GameObject text = transform.GetChild(0).gameObject;
        text.SetActive(false);
    }
}
