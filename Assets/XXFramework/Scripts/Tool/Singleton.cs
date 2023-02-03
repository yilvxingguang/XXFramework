using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单例类的基类，用来单例的继承
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T : new()
{

    private static T _Instance = new T();

    protected Singleton()
    {
        Debug.Assert(null == _Instance);
    }

    public static T Instance
    {
        get { return _Instance; }
    }

}
