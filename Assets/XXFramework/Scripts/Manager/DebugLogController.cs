using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LogColor
{
    green,
    black,
    blue,
    cyan,
    white,
    yellow,
    red,
    gray
}
public class DebugLogController : UnitySingleton<DebugLogController>
{
     public static bool enable = true;

    
   /// <summary>
   /// 普通输出
   /// </summary>
   /// <param name="message"></param>
   /// <param name="color"></param>
   /// <param name="bold"></param>
   /// <param name="italic"></param>
    public static void Log(object message, LogColor color = LogColor.gray,bool bold = false,bool italic = false,bool timeStamp=true)
    {
        if (!enable)
        {
            return;
        }
        Debug.Log(Message(message, color,bold,italic,timeStamp));
    }
    /// <summary>
    /// 输出对象（自定义的）
    /// </summary>
    /// <param name="content"></param>
    /// <param name="color"></param>
    /// <param name="bold"></param>
    /// <param name="italic"></param>
    /// <typeparam name="T"></typeparam>
    public static void LogObject<T>(T content, LogColor color = LogColor.black,bool bold = false,bool italic = false)
    {
        if (!enable)
        {
            return;
        }
        
        Debug.Log(Message(typeof(T).Name,color,bold,italic) + "\n" + ObjectMessage(content));
    }
    
    /// <summary>
    /// 输出List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="content"></param>
    public static void LogList<T>(List<T> content)
    {
        if(!enable || content == null || content.Count <= 0)
        {
            return;
        }

        var result = Title(typeof(T).Name + " List", 0, LogColor.green) + "\n\n";
        for (int i = 0; i < content.Count; i++)
        {
            result += Title(typeof(T).Name+"_" + i, 1, LogColor.green) + "\n";
            result += ObjectMessage<T>(content[i]) + "\n";
        }
        result += Title("End", 0, LogColor.green);

        Debug.Log(result);
    }

    /// <summary>
    /// 输出数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="content"></param>
    public static void LogArray<T>(T[] content)
    {
        if (!enable || content == null || content.Length <= 0)
        {
            return;
        }

        var result = Title(typeof(T).Name + " List", 0, LogColor.green) + "\n";
        for (int i = 0; i < content.Length; i++)
        {
            result += Title(typeof(T).Name + "_" + i, 1, LogColor.green) + "\n";
            result += ObjectMessage<T>(content[i]) + "\n";
        }
        result += Title("End", 0, LogColor.green);

        Debug.Log(result);
    }
    /// <summary>
    /// Warning输出
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    /// <param name="bold"></param>
    /// <param name="italic"></param>
    public static void Warning(object message, LogColor color = LogColor.yellow,bool bold = false,bool italic = false)
    {
        if (!enable)
        {
            return;
        }
        Debug.LogWarning(Message(message, color,bold,italic));
    }
    /// <summary>
    /// Error输出
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    /// <param name="bold"></param>
    /// <param name="italic"></param>
    public static void Error(object message, LogColor color = LogColor.red,bool bold = false,bool italic = false)
    {
        if (!enable)
        {
            return;
        }
        Debug.LogError(Message(message, color,bold,italic));
    }

    public override void Awake()
    {
        
    }

    private static string Message(object message, LogColor color = LogColor.black,bool bold = false,bool italic = false,bool timeStamp=true)
    {
        int time = (int)(Time.realtimeSinceStartup * 1000);
        var content = string.Format("<color={0}>{1}</color>",color.ToString(), message+"  Time:"+time/1000.0);
        content = bold ? string.Format("<b>{0}</b>", content) : content;
        content = italic ? string.Format("<i>{0}</i>", content) : content;
        
        return content;
    }

    private static string Title(object title, int level, LogColor color)
    {
        return Message(string.Format("{0}{1}{2}{1}", Space(level * 2), Character(16 - level * 2), title), color);
    }

    private static string ObjectMessage<T>(T content)
    {
        var result = "";

        var fields = typeof(T).GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            result += Space(4) + Message(fields[i].Name + " : ", LogColor.green, true) + fields[i].GetValue(content) + "\n";
        }

        var properties = typeof(T).GetProperties();
        for (int i = 0; i < properties.Length; i++)
        {
            result += Space(4) + Message(properties[i].Name + " : ", LogColor.green, true) + properties[i].GetValue(content, null) + "\n";
        }

        return result;
    }
    private static string Space(int number)
    {
        var space = "";
        for (int i = 0; i < number; i++)
        {
            space += " ";
        }
        return space;
    }

    private static string Character(int number, string character = "=")
    {
        var result = "";
        for (int i = 0; i < number; i++)
        {
            result += "=";
        }
        return result;
    }
}
