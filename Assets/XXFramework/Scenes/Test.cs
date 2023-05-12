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
        NullTypeExample();

        func += NullTypeExample;
        Debug.Log(count);
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
