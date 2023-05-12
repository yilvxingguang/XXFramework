using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ParseCSV
{
    /// <summary>
    /// 检测CSV文件是否存在 
    /// </summary>
    /// <param name="filepath">路径</param>
    /// <returns></returns>
    public static bool IsExists(string filepath)
    {
        Debug.Log(filepath);
        if (File.Exists(filepath))
        {
            Debug.LogWarning(filepath + "  CSV文件已存在 ");
            return true;
        }
        Debug.LogWarning(filepath + "   CSV文件不存在 ");
        return false;
    }
    /// <summary>
    /// 创建CSV文件
    /// </summary>
    /// <param name="filepath">路径</param>
    /// <param name="filename">CSV名字</param>
    public static void Generate(string filepath, string filename)
    {
        string path = filepath + "/" + filename;
        if (!IsExists(path))
        {
            File.Create(path);
            Debug.LogWarning(path + " CSV文件创建完毕 ");
        }
    }
    /// <summary>
    /// 删除CSV文件
    /// </summary>
    /// <param name="filepath">路径</param>
    /// <param name="filename">CSV名</param>
    public static void Delete(string filepath, string filename)
    {
        string path = filepath + "/" + filename;
        if (IsExists(path))
        {
            File.Delete(path);
            Debug.LogWarning(path + " CSV文件删除完毕 ");
        }
    }

    /// <summary>
    /// 返回 一个字典 string数组
    /// </summary>
    /// <param name="filepath"></param>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static Dictionary<string, string[]> ReadDataCsvDic(string filepath, string filename)
    //{

    //    string path = filepath + "/" + filename;
    //    Dictionary<string, string[]> dic = new Dictionary<string, string[]>();
    //    if (IsExists(path))
    //    {
    //        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
    //        StreamReader sr = new StreamReader(fs);

    //        string line = "";
    //        while (null != (line = sr.ReadLine()))
    //        {
    //            if (!dic.ContainsKey(line.Split(',')[0]))
    //            {
    //                dic.Add(line.Split(',')[0], line.Split(','));
    //                Debug.Log(line.Split(',')[0] + "-------------" + line.Split(','));

    //            }
    //        }
    //        sr.Close();
    //        fs.Close();
    //    }
    //    return dic;
    //}

    {

        string path = filepath + "/" + filename;
        Dictionary<string, string[]> dic = new Dictionary<string, string[]>();
        if (IsExists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            while (null != (line = sr.ReadLine()))
            {
                Debug.Log(line.Split(',')[1]);
                if (!dic.ContainsKey(line.Split(',')[1]))
                {
                    dic.Add(line.Split(',')[0], line.Split(','));
                    Debug.Log(line.Split(',')[0] + "-------------" + line.Split(','));

                }
            }
            sr.Close();
            fs.Close();
        }
        return dic;
    }
    static Dictionary<string, string[]> testDic = ReadDataCsvDic(Application.streamingAssetsPath, "TestQue2.csv");

    public static bool IsExitQuestionList(string modelName)
    {
        foreach (var itemDic in testDic)
        {
            if(itemDic.Value.ToArray()[1].Equals(modelName))
                return true;
        }
        return false;
    }

    public static List<string> DicToList(string modelName)
    {
        // 
        Debug.LogError(IsExitQuestionList(modelName));
        List<string> CSVList = new List<string>();
        foreach (var itemDic in testDic)
        {
            Debug.Log(itemDic.Value.ToArray()[1]);
            if (itemDic.Value.ToArray()[1].Equals(modelName))
            {
                CSVList.Add(itemDic.Value.ToArray()[2]);
            }
        }
        return CSVList;
    }


    //public static List<string> DicToList(string modelName)
    //{
    //    Dictionary<string, string[]> testDic = ReadDataCsvDic(Application.dataPath, "TestQue2.csv");
    //    List<string> CSVList = new List<string>();
    //    foreach (var itemDic in testDic)
    //    {
    //        Debug.Log(itemDic.Value.ToArray()[1]);
    //        if (itemDic.Value.ToArray()[1].Equals(modelName))
    //        {
    //            CSVList.Add(itemDic.Value.ToArray()[2]);
    //        }
    //    }
    //    return CSVList;
    //}

}

