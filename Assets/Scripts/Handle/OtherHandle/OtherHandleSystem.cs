using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 其他处理
/// </summary>
public class OtherHandleSystem : Singleton<OtherHandleSystem>
{
    private GoodsHandle goodsHandle;
    /// <summary>
    /// 工具处理
    /// </summary>
    public GoodsHandle GoodsHandle
    {
        get { return goodsHandle ?? (goodsHandle = new GoodsHandle()); }
    }

    /// <summary>
    /// 工具预加载
    /// </summary>
    public void GoodsLoadAssetAsync(string buildName,string stepName,string goodsName,Action completedAction)
    {
        GoodsHandle.LoadGoodsAsset("Goods/"+buildName+"/"+stepName+"/"+ goodsName +".prefab",completedAction+=delegate { Debug.Log(goodsName + "工具预加载完毕"); });     
    }

    private AudiosHandle audiosHandle;
    /// <summary>
    /// 工具音乐处理
    /// </summary>
    public AudiosHandle AudiosHandle
    {
        get { return audiosHandle ?? (audiosHandle = new AudiosHandle()); }
    }

    /// <summary>
    /// 预加载步骤音乐 
    /// </summary>
    /// <param name="isStep">是否为步骤音乐</param>
    public void AudioLoadAssetAsync(string buildName,string stepIndex,string goodsIndex,Action action=null)
    {
        string  Keys = null;
        if (goodsIndex==null)
        {
            Keys = "Audios/"+buildName+"/"+stepIndex+".mp3";
        }
        else
        {
            Keys = "Audios/"+buildName+"/"+stepIndex + "-" + goodsIndex+".mp3" ;
        }
         AudiosHandle.LoadAudioAssetAsyn(Keys, action);      
    }


    private SpriteHandle imageSpriteHandle;
    /// <summary>
    /// sprite处理
    /// </summary>
    public  SpriteHandle ImageSpriteHandle
    {
        get { return imageSpriteHandle ?? (imageSpriteHandle = new SpriteHandle()); }
    }

    /// <summary>
    /// 图片赋值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="action"></param>
    public void ImageSpriteAssetAsync(string key,Action action=null)
    {
        string keys = "Images/" + key;
        ImageSpriteHandle.LoadSpriteAssetAsyn(keys,action);
    }


}

