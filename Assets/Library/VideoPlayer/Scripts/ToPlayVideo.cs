using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;


public class ToPlayVideo : MonoBehaviour
{
    public VideoClip videoClip;
    internal VideoPlayer videoPlayer;

    private Text videoTimeText;
    //   public Text videoNameText;
    private Button btnClose, btnPauseOrPlay, btnVoice;
    public Slider videoTimeSlider, videoVolumeSlider;
    private RawImage VideoPlayRawImage;
    private Image VolumeImage;
    private Transform videoUIs;
    public Sprite[] btnPauseOrPlayImage;

    private int currentHour, currentMinute, currentSecond;
    private int clipHour, clipMinute, clipSecond;

    void Awake()
    {
        Transform ts = transform.Find("VideoPlayRawImage");
        videoPlayer = transform.Find("VideoPlayRawImage").GetComponent<VideoPlayer>();
        VideoPlayRawImage = ts.GetComponent<RawImage>();

        videoUIs = transform.Find("VideoUIs");
        videoTimeText = videoUIs.Find("VedeoProgress/TimeText").GetComponent<Text>();
        videoTimeSlider = videoUIs.Find("VedeoProgress/VideoTimeSlider").GetComponent<Slider>();
        videoVolumeSlider = videoUIs.Find("VideoVolumeSlider").GetComponent<Slider>();

        if (videoClip != null)
            SetVideoClip(videoClip);


        btnClose = videoUIs.Find("BtnCloseMovie").GetComponent<Button>();
        //btnClose.onClick.AddListener(delegate()
        //{
        //    gameObject.SetActive(false);
        //});

        btnPauseOrPlay = videoUIs.Find("BtnPauseOrPlay").GetComponent<Button>();
        btnPauseOrPlay.image.sprite = btnPauseOrPlayImage[0];
        btnPauseOrPlay.onClick.AddListener(BtnPauseOrPlayClickEvent);

        btnVoice = videoUIs.Find("BtnVoice").GetComponent<Button>();
        VolumeImage = btnVoice.transform.Find("VolumeImage").GetComponent<Image>();
        videoVolumeSlider.gameObject.SetActive(false);
        btnVoice.onClick.AddListener(delegate ()
        {
            videoVolumeSlider.gameObject.SetActive(true);
        });


    }

    void Update()
    {
        if (videoPlayer.texture == null)
        {
            return;
        }
        if (videoTimeSlider.value != 1)
        {
            if (btnPauseOrPlay.image.sprite == btnPauseOrPlayImage[1])
            {
                videoPlayer.Pause();
            }
            else
            {
                videoPlayer.Play();
            }
        }
        HideVideoVolumeSlider();
        VideoPlayRawImage.texture = videoPlayer.texture;
        ShowVideoTime();
        videoPlayer.SetDirectAudioVolume(0, videoVolumeSlider.value);
        VolumeImage.fillAmount = videoVolumeSlider.value;
    }

    private void ShowVideoTime()
    {
        // 当前的视频播放时间       
        currentHour = (int)videoPlayer.time / 3600;
        currentMinute = (int)(videoPlayer.time - currentHour * 3600) / 60;
        currentSecond = (int)(videoPlayer.time - currentHour * 3600 - currentMinute * 60); // 把当前视频播放的时间显示在 Text 上        
        videoTimeText.text = string.Format("{0:D2}:{1:D2}:{2:D2} / {3:D2}:{4:D2}:{5:D2}",
            currentHour, currentMinute, currentSecond, clipHour, clipMinute, clipSecond); // 把当前视频播放的时间比例赋值到 Slider 上       
        videoTimeSlider.value = (float)(videoPlayer.time / videoPlayer.clip.length);
    }

    private void BtnPauseOrPlayClickEvent()
    {
        if (btnPauseOrPlay.image.sprite == btnPauseOrPlayImage[0])
        {
            btnPauseOrPlay.image.sprite = btnPauseOrPlayImage[1];
        }
        else
        {
            btnPauseOrPlay.image.sprite = btnPauseOrPlayImage[0];
            videoPlayer.Play();
        }
    }

    /// <summary>
    /// 点击任意处隐藏声音slider
    /// </summary>
    private void HideVideoVolumeSlider()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (!(EventSystem.current.IsPointerOverGameObject() == true
                    && EventSystem.current.currentSelectedGameObject != null
                        && EventSystem.current.currentSelectedGameObject.name == "VideoVolumeSlider"))
                {

                    videoVolumeSlider.gameObject.SetActive(false);
                }

                if (EventSystem.current.IsPointerOverGameObject() == true)
                {
                    videoUIs.gameObject.SetActive(true);
                    //VideoUIsManager();
                    CancelInvoke("HideVideoUIs");
                    Invoke("HideVideoUIs", 3);
                }
                //if (EventSystem.current.IsPointerOverGameObject() == true)
                //{

                //    if (!(EventSystem.current.currentSelectedGameObject != null
                //        && EventSystem.current.currentSelectedGameObject.name == "VideoVolumeSlider"))
                //    {
                //        videoVolumeSlider.gameObject.SetActive(false);
                //        Debug.Log(2);
                //    }
                //    Debug.Log(3);
                //    CancelInvoke("HideVideoUIs");
                //    Invoke("HideVideoUIs", 3);
                //}
            }
        }
    }
    private void HideVideoUIs()
    {
        videoUIs.gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置视频片段
    /// </summary>
    /// <param name="_videoClip"></param>
    public void SetVideoClip(VideoClip _videoClip)
    {
        videoClip = _videoClip;

        videoPlayer.clip = videoClip;
        Debug.Log(videoPlayer.clip);
        clipHour = (int)videoPlayer.clip.length / 3600;
        clipMinute = (int)(videoPlayer.clip.length - clipHour * 3600) / 60;
        clipSecond = (int)(videoPlayer.clip.length - clipHour * 3600 - clipMinute * 60);
        videoPlayer.Play();
        videoVolumeSlider.value = 0.6f;
        videoUIs.gameObject.SetActive(true);
        Invoke("HideVideoUIs", 3);
    }

    /// <summary>
    /// 设置播放暂停
    /// </summary>
    /// <param name="isPlay"></param>
    public void PlayClip(bool isPlay = true)
    {
        if (isPlay)
        {
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Pause();
        }
    }
    /// <summary>
    /// 清空视频片段
    /// </summary>
    public void DeleteVideoClip()
    {
        videoPlayer.clip = null;
    }
}
