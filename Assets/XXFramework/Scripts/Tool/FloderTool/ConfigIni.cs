
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
//注意 ： 打包之后路径应为全部英文  否则会读取不了ini的值
public class ConfigIni
{
    private string path; //ini文件的路径
    public ConfigIni(string path)
    {
        this.path = path;
        if (!IsIniPath())
        {
            Debug.LogError(path + "路径不正确！");
        }
    }
    [DllImport("kernel32")]
    public static extern long WritePrivateProfileString(string section, string key, string value, string path);
    [DllImport("kernel32")]
    public static extern int GetPrivateProfileString(string section, string key, string deval, StringBuilder stringBuilder, int size, string path);

    //写入ini文件
    public void WriteIniContent(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, this.path);
    }
    //读取ini文件
    public string ReadIniContent(string section, string key)
    { 
        StringBuilder temp = new StringBuilder(255);
        int i = GetPrivateProfileString(section, key, "", temp, 255, this.path);

        if (temp.ToString() == null || temp.ToString() == "")
        {
            Debug.LogError("注意：配置文件[" + section + "]键" + key + "为空 或者路径中含有中文");
        }
        return temp.ToString();
    }
    //判断路径是否正确
    public bool IsIniPath()
    {
        return File.Exists(this.path);

    }
}

