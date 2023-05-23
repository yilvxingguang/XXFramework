using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AssetDic
{

    //资源存储字典
    private Dictionary<string, GameObject> gameObjectDic;
    private Dictionary<string, AudioClip> audioDic;
    private Dictionary<string, Sprite> spriteDic;
    private Dictionary<string, GameObject> panelObjectDic;
    private Dictionary<string, Mesh> meshsDic;
    private Dictionary<string, Material> materialdsDic;
    private Dictionary<string, TextAsset> textAssetsDic;

    /// <summary>
    /// 物品字典
    /// </summary>
    public Dictionary<string, GameObject> GameObjectDic
    {
        get { return gameObjectDic ?? (gameObjectDic = new Dictionary<string, GameObject>()); }
    }
    /// <summary>
    /// 音效字典
    /// </summary>
    public Dictionary<string, AudioClip> AudioDic
    {
        get { return audioDic ?? (audioDic = new Dictionary<string, AudioClip>()); }
    }
    /// <summary>
    /// 精灵字典
    /// </summary>
    public Dictionary<string, Sprite> SpriteDic
    {
        get { return spriteDic ?? (spriteDic = new Dictionary<string, Sprite>()); }
    }
    /// <summary>
    /// 面板字典
    /// </summary>
    public Dictionary<string, GameObject> PanelObjectDic
    {
        get { return panelObjectDic ?? (panelObjectDic = new Dictionary<string, GameObject>()); }
    }
    /// <summary>
    /// 网格字典
    /// </summary>
    public Dictionary<string, Mesh> MeshsDic
    {
        get { return meshsDic ?? (meshsDic = new Dictionary<string, Mesh>()); }
    }
    /// <summary>
    /// 材质字典
    /// </summary>
    public Dictionary<string, Material> MaterialdsDic
    {
        get { return materialdsDic ?? (materialdsDic = new Dictionary<string, Material>()); }
    }
    /// <summary>
    /// 文本字典
    /// </summary>
    public Dictionary<string, TextAsset> TextAssetsDic
    {
        get { return textAssetsDic ?? (textAssetsDic = new Dictionary<string, TextAsset>()); }
    }

    /// <summary>
    /// 清空所有字典
    /// </summary>
    public void ClearAllDic()
    {
        gameObjectDic.Clear();
        audioDic.Clear();
        spriteDic.Clear();
        panelObjectDic.Clear();
        meshsDic.Clear();
        materialdsDic.Clear();
        textAssetsDic.Clear();
    }
}

