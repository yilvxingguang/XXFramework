using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源加载基类
/// </summary>
public interface IAsset
{

    /// <summary>
    /// 加载音乐
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    AudioClip LoadAudioClip(string name);
    /// <summary>
    /// 加载物体
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    GameObject LoadGameObject(string name);
    /// <summary>
    /// 加载精灵
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Sprite LoadSprite(string name);
    /// <summary>
    /// 加载面板
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    GameObject LoadPanelObject(string name);
    /// <summary>
    /// 加载网格
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Mesh LoadMesh(string name);
    /// <summary>
    /// 加载材质
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Material LoadMaterials(string name);
    /// <summary>
    /// 加载文本文件
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    TextAsset LoadTextAsset(string name);
}
