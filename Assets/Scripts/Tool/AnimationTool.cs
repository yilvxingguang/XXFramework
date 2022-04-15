using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class AnimationTool 
{
    
    
    
    
/// <summary>
/// 遍历文件夹内的所有Animation的名字
/// </summary>
/// <param name="animName">文件夹的名字</param>
/// <returns>动画的名字</returns>
   public static List<string> AnimationName(string animName)
    {
        List<string> animationName = new List<string>();
        if (Directory.Exists(animName))
        {
            
            DirectoryInfo direction = new DirectoryInfo(animName);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
            Debug.Log(animName.Length);
            for (int i = 0; i < files.Length; i++)
            {
                Debug.Log("Home" + files[i].Name);
                animationName[i] = files[i].Name;
            }
            
        }
        return animationName;

    }
    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="animName">文件名字</param>
    public static void PlayAnim(string animName)
    {
        foreach (var item in AnimationName(animName))
        {
            string animname = item;
            Animation animation;
            animation = GameObject.Find("FishLead").GetComponent<Animation>();
            animation.Play(animname);
            ///动画播放后一直保持播放完之后的状态
            //KeepAnim();
        }
    }
    /// <summary>
    /// 播放完之后一直保持这个状态
    /// </summary>
    public static void KeepAnim()
    {

    }



}
