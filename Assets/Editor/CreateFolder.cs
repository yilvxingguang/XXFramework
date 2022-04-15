using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class CreateFolder
{

    [UnityEditor.MenuItem("Tools/前期准备/创建基础文件夹")]
    public static void CreateFolders()
    {
        string pathFolder = Application.dataPath;
        List<string> foldersName = new List<string>();

        foldersName.Add("Font");
        foldersName.Add("Library");
        foldersName.Add("Models");
        foldersName.Add("Plugins");
        foldersName.Add("Prefabs");
        foldersName.Add("Resources");
        foldersName.Add("Scenes");
        foldersName.Add("Scripts");
        foldersName.Add("StreamingAssets");
        foldersName.Add("Terrains");
        foldersName.Add("Textures");

        foreach (var item in foldersName)
        {
            GenerateFolder(pathFolder, item);
        }

    }

    /// <summary>
    /// 检测文件夹是否存在
    /// </summary>
    /// <param name="folderpath"></param>
    /// <returns></returns>
    public static bool IsExistsFolder(string folderpath)
    {
        if (Directory.Exists(folderpath))
        {
            Debug.LogWarning(folderpath + " 路径文件夹已存在 ");
            return true;
        }
        Debug.LogWarning(folderpath + " 路径文件夹不存在 ");
        return false;
    }
    /// <summary>
    /// 创建文件夹
    /// </summary>
    /// <param name="filepath">路径</param>
    /// <param name="filename">文件夹名字</param>
    public static void GenerateFolder(string folderpath, string foldername)
    {
        string path = folderpath + "/" + foldername;
        if (!IsExistsFolder(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogWarning(path + " 路径文件夹创建完毕 ");

        }
    }
    /// <summary>
    /// 删除文件夹
    /// </summary>
    /// <param name="folderpath">路径</param>
    /// <param name="foldername">文件夹名</param>
    public static void DeleteFolder(string folderpath, string foldername)
    {
        string path = folderpath + "/" + foldername;
        if (IsExistsFolder(path))
        {
            Directory.Delete(path);
            Debug.LogWarning(path + " 路径文件夹删除完毕 ");
        }
    }

}
