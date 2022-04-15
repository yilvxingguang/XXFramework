using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源加载
/// </summary>
public  class AssetManager
{
    private static AssetManager instance;
    /// <summary>
    /// 单例
    /// </summary>
    public static AssetManager Instance
    {
        get { return instance ?? (instance = new AssetManager()); }
    }


    private  AssetPath assetPath;
    /// <summary>
    /// 资源路径
    /// </summary>
    public  AssetPath AssetPath
    {
        get { return assetPath ?? (assetPath = new AssetPath()); }
    }


    private  AssetDic assetDic;
    /// <summary>
    /// 资源字典
    /// </summary>
    public  AssetDic AssetDic
    {
        get { return assetDic ?? (assetDic = new AssetDic()); }
    }


    private  IAsset resourceAsset = null;
    /// <summary>
    /// Resource加载路径
    /// </summary>
    public  IAsset ResourceAsset
    {
        get { return resourceAsset ?? (resourceAsset = new ResourcesAsset()); }
    }


}
