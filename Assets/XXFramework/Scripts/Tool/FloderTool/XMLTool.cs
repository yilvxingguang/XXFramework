using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLTool
{
    private string path; //xml文件的路径
    public XMLTool(string path)
    {
        this.path = path;
        if (!IsPath(path))
        {
            Debug.LogError(path + "路径不正确！");
        }
    }
    public string ReadXml(string ParentNode, string Node, string BaseNode="Config")
    {
        if (IsPath(path))
        {
            XmlDocument xml = new XmlDocument();
            XmlReader reader = XmlReader.Create(path);
            xml.Load(reader);

            string innerText = xml.SelectSingleNode(BaseNode).SelectSingleNode(ParentNode).SelectSingleNode(Node).InnerText;
            reader.Close();
            return innerText;       
        }

        return path+"文件不存在";

    }

    private bool IsPath(string path)
    {
        if(!File.Exists(path))
        {
            Debug.LogError("请检查路径是否正确："+path);
        }
        return File.Exists(path);
    }
}

