
//using System;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using Aspose.Words;
//using System.Windows.Forms;

//public class ParseWorld
//{
//    /// <summary>
//    /// 检测World文件是否存在 
//    /// </summary>
//    /// <param name="filepath">路径</param>
//    /// <returns></returns>
//    public static bool IsExists(string filepath)
//    {
//        Debug.Log(filepath);
//        if (File.Exists(filepath))
//        {
//            Debug.LogWarning(filepath + "  World文件已存在 ");
//            return true;
//        }
//        Debug.LogWarning(filepath + "   World文件不存在 ");
//        return false;
//    }
//    /// <summary>
//    /// 创建World文件
//    /// </summary>
//    /// <param name="filepath">路径</param>
//    /// <param name="filename">World名字</param>
//    public static void Generate(string filepath, string filename)
//    {
//        string path = filepath + "/" + filename + ".doc";
//        if (!IsExists(path))
//        {
//            File.Create(path);
//            Debug.LogWarning(path + " World文件创建完毕 ");
//        }
//    }
//    /// <summary>
//    /// 删除World文件
//    /// </summary>
//    /// <param name="filepath">路径</param>
//    /// <param name="filename">World名</param>
//    public static void Delete(string filepath, string filename)
//    {
//        string path = filepath + "/" + filename + ".doc";
//        if (IsExists(path))
//        {
//            File.Delete(path);
//            Debug.LogWarning(path + " World文件删除完毕 ");
//        }
//    }
//    /// <summary>
//    /// 读取World文件
//    /// </summary>
//    /// <param name="filepath">文件路径</param>
//    /// <param name="filename">文件名</param>
//    /// <returns></returns>
//    public static string UpdateToPDF(string filepath, string filename,Dictionary<string,string> dic)
//    {
//        string pathPdf = null;
//        FolderBrowserDialog dialog = new FolderBrowserDialog();
//        dialog.Description = "请选择想要保存的路径";
//        if (dialog.ShowDialog() == DialogResult.OK)
//        {
//            pathPdf = dialog.SelectedPath;
//        }
//        //string pathPdf = UnityEditor.EditorUtility.OpenFolderPanel("选择实验报告输出目录", Application.dataPath, "");
//        string content = null;
//        string path = Path.GetFullPath(filepath + "/" + filename + ".doc").ToString();
//        if (IsExists(path))
//        {
//            Document doc = new Document(path);


//            foreach (var item in dic)
//            {
//                doc.Range.Replace(item.Key, item.Value, false, true);
//            }
//            //doc.Save(path);

//            // string pathPdf = UnityEditor.EditorUtility.OpenFolderPanel("选择材质文件夹", Application.dataPath, "");
//            Debug.Log(pathPdf);
//            doc.Save(pathPdf +"/"+ dic["ID"]+" "+dic["Name"] +"的实验报告.pdf", Aspose.Words.SaveFormat.Pdf);
//        }

//        return content;
//    }

//}

