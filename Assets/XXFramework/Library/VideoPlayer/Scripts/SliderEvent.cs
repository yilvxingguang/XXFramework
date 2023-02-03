using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderEvent : MonoBehaviour,IDragHandler
{
    [SerializeField]
    private ToPlayVideo toPlayVideo;
    

    public void OnDrag(PointerEventData pointerEventData)
    {
        SetVideoValueChange();
    }

    private void SetVideoValueChange()
    {
        toPlayVideo.videoPlayer.time = toPlayVideo.videoTimeSlider.value * toPlayVideo.videoPlayer.clip.length;
    }
}
