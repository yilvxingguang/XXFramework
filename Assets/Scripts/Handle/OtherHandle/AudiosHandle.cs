using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
/// <summary>
/// 音乐处理
/// </summary>
public class AudiosHandle
{
    private AudioSource audioSource;
    private AudioClip audioClip;

    private   Action action=null;
    private AsyncOperationHandle<AudioClip> clipAsync;
    public AudiosHandle()
    {
        audioSource = GameObject.Find("LoopProject").GetComponent<AudioSource>();
    }
 
    public void LoadAudioAssetAsyn(string audiosKeys,Action actions=null)
    {
        Debug.Log("预加载语音Key值：" + audiosKeys);

        action = actions;

        Addressables.LoadAssetAsync<AudioClip>(audiosKeys).Completed += Audios_Completed;
    }
    /// <summary>
    /// 语音预加载成功
    /// </summary>
    /// <param name="obj"></param>
    private void Audios_Completed(AsyncOperationHandle<AudioClip> obj)
    {
        //卸载上个语音
        if (clipAsync.IsValid()) Addressables.Release(clipAsync);
        //赋值目前语音
        clipAsync = obj;
        audioClip = obj.Result;
        Debug.Log("语音预加载完成" + audioClip.name);

        action?.Invoke();

    }

    /// <summary>
    /// 播放语音
    /// </summary>
    public void PlayAudio()
    {
        Debug.Log("语音播放成功:"+audioClip.name);
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    /// <summary>
    /// 暂停语音
    /// </summary>
    public void StopAudio()
    {
        audioSource.Stop();
    }

    /// <summary>
    /// 是否还在播放
    /// </summary>
    /// <returns></returns>
    public bool IsPlaying
    {
        get { return audioSource.isPlaying; }  
    }

}

