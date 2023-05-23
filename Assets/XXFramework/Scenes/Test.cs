using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Backpack
{
    public List<int> itemList;
    public int backpackID;
    public void PrintBackpackInfo()
    {
        Debug.Log("this is a Backpack");
    }
}


public class Test : MonoBehaviour
{
    System.Func<List<int>> func = null;
    int count => func?.Invoke()?.Count ?? -1;
    // Start is called before the first frame update
    void Start()
    {
        //NullTypeExample();

        //func += NullTypeExample;
        //Debug.Log(count);

        //AssetBundlesManager.Instance.LoadResourceAsync<Material>("ab", "Test", null);
        //StartCoroutine(LoadABRes("ab", "Test"));

        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "ab");
        //第二步 加载AB包中的资源（三种方式）
        GameObject obj = (GameObject)ab.LoadAsset("Cube");  //仅使用名字加载，会出现同名不同类型资源分不清的情况，不建议使用
        //obj = ab.LoadAssert<GameObject>("Cube"); //使用泛型加载
        //obj = ab.LoadAssert("Cube", typeof(GameObject) as GameObject); //Type指定泛型（lua不支持泛型）
        Instantiate(obj);  //实例化
    }
    IEnumerator LoadABRes(string ABName, string resName)
    {
        //第一步 加载资源包
        AssetBundle abcr = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "ab");
        yield return abcr;

        //加载资源
        AssetBundleRequest abq = abcr.LoadAssetAsync(resName, typeof(Material)); //若已知是图片资源
        yield return abq;
        Debug.Log(abq.asset.name);
        //img.Sprite = abq.asset as ma;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int> NullTypeExample()
    {
        List<int> list = new List<int>();
        Backpack backpack = null;
        int backpackID = backpack?.backpackID ?? -1;
        list.Add(backpackID);
        Debug.Log("背包ID为：" + backpackID);
        return list;
    }
}
