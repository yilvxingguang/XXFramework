using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SpriteHandle
{
    private Sprite sprite;

    private Action action = null;
    private AsyncOperationHandle<Sprite> spriteAsync;
    public SpriteHandle()
    {
        
    }

    public void LoadSpriteAssetAsyn(string spriteKeys, Action actions = null)
    {
        Debug.Log("预加载图片Key值：" + spriteKeys);

        action = actions;

        Addressables.LoadAssetAsync<Sprite>(spriteKeys).Completed += Audios_Completed;
    }
    /// <summary>
    /// 图片预加载成功
    /// </summary>
    /// <param name="obj"></param>
    private void Audios_Completed(AsyncOperationHandle<Sprite> obj)
    {
        
        if (spriteAsync.IsValid()) Addressables.Release(spriteAsync);
        
        spriteAsync = obj;
        sprite = obj.Result as Sprite;
        Debug.Log("图片预加载完成" + sprite.name);

        action?.Invoke();
    }


    /// <summary>
    /// sprite
    /// </summary>
    /// <returns></returns>
    public Sprite SpriteAsset()
    {
        return sprite;
    }
}

