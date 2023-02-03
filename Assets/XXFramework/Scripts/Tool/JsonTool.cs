using System;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Json解析工具
/// </summary>
/// <typeparam name="T"></typeparam>
public static class JsonTool<T>
{
    /// <summary>
    /// 读取Json文件（赋值给对象）
    /// </summary>
    /// <param name="jsonPath">文件路径</param>
    /// <returns>T类型的函数</returns>
    public static T AssignmentJson(string jsonPath)
    {
        //Debug.Log(jsonPath);
        if (!File.Exists(jsonPath))//Json文件是否存在
        {
            Debug.LogError("JSON文件不存在");
        }
        string jsonString = File.ReadAllText(jsonPath);
        return JsonMapper.ToObject<T>(jsonString);
    }

}
