using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resource资源资源加载
/// </summary>
public class ResourcesAsset : IAsset
{
    private AssetDic resourceAssetDic = AssetManager.Instance.AssetDic;
    private AssetPath resourceAssetPath = AssetManager.Instance.AssetPath;

    /// <summary>
    /// 音乐加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public AudioClip LoadAudioClip(string name)
    {
        if (resourceAssetDic.AudioDic.ContainsKey(name))
        {
            return resourceAssetDic.AudioDic[name];
        }
        else
        {
            string path = resourceAssetPath.AudioPath + name;
            AudioClip audio = Resources.Load(path) as AudioClip;
            if (audio == null)
            {
                Debug.LogError("无法加载资源，路径:" + path); return null;
            }
            resourceAssetDic.AudioDic.Add(name, audio);
            return audio;
        }
    }
    /// <summary>
    /// 物体加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadGameObject(string name)
    {
        if (resourceAssetDic.GameObjectDic.ContainsKey(name))
        {
            return resourceAssetDic.GameObjectDic[name];
        }
        else
        {
            string path = resourceAssetPath.GameObjectPath + name;
            GameObject obj = Resources.Load(path) as GameObject;
            if (obj == null)
            {
                Debug.LogError("无法加载资源，路径:" + path); return null;
            }
            resourceAssetDic.GameObjectDic.Add(name, obj);
            return obj;
        }
    }
    /// <summary>
    /// 精灵加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Sprite LoadSprite(string name)
    {

        if (resourceAssetDic.SpriteDic.ContainsKey(name))
        {
            return resourceAssetDic.SpriteDic[name];
        }
        else
        {
            string path = resourceAssetPath.SpritePath + name;
            Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
            if (sprite == null)
            {
                Debug.LogError("无法加载资源，路径:" + path); return null;
            }
            resourceAssetDic.SpriteDic.Add(name, sprite);
            return sprite;
        }
    }
    /// <summary>
    /// 面板加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadPanelObject(string name)
    {
        if (resourceAssetDic.PanelObjectDic.ContainsKey(name))
        {
            return resourceAssetDic.PanelObjectDic[name];
        }
        else
        {
            string path = resourceAssetPath.PanelPath + name;
            GameObject obj = Resources.Load(path) as GameObject;
            if (obj == null)
            {
                Debug.LogError("无法加载资源，路径:" + path); return null;
            }
            resourceAssetDic.PanelObjectDic.Add(name, obj);
            return obj;
        }
    }
    /// <summary>
    /// 网格加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Mesh LoadMesh(string name)
    {

        if (resourceAssetDic.MeshsDic.ContainsKey(name))
        {
            return resourceAssetDic.MeshsDic[name];
        }
        else
        {
            string path = resourceAssetPath.MeshsPath + name;
            Mesh obj = Resources.Load(path, typeof(Mesh)) as Mesh;
            if (obj == null)
            {
                Debug.LogError("无法加载资源，路径:" + path); return null;
            }
            resourceAssetDic.MeshsDic.Add(name, obj);
            return obj;
        }
    }
    /// <summary>
    /// 材质加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Material LoadMaterials(string name)
    {
        if (resourceAssetDic.MaterialdsDic.ContainsKey(name))
        {
            return resourceAssetDic.MaterialdsDic[name];
        }
        else
        {
            string path = resourceAssetPath.MaterialsPath + name;
            Material obj = Resources.Load(path, typeof(Material)) as Material;
            if (obj == null)
            {
                Debug.LogError("无法加载资源，路径:" + path); return null;
            }
            resourceAssetDic.MaterialdsDic.Add(name, obj);
            return obj;
        }
    }
    /// <summary>
    /// 文本加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public TextAsset LoadTextAsset(string name)
    {
        if (resourceAssetDic.TextAssetsDic.ContainsKey(name))
        {
            return resourceAssetDic.TextAssetsDic[name];
        }
        else
        {
            string path = resourceAssetPath.textAssetsPath + name;
            TextAsset obj = Resources.Load(path, typeof(TextAsset)) as TextAsset;
            if (obj == null)
            {
                Debug.LogError("无法加载资源，路径:" + path); return null;
            }
            resourceAssetDic.TextAssetsDic.Add(name, obj);
            return obj;
        }
    }
}
