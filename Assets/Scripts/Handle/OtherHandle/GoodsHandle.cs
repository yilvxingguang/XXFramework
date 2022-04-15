using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
/// <summary>
/// 工具动画
/// </summary>
public class GoodsHandle
{
    /// <summary>
    /// 预加载的goods
    /// </summary>
    private GameObject GoodsAsset;
    /// <summary>
    /// 实例化的Goods
    /// </summary>
    private GameObject Goods;

    private AsyncOperationHandle<GameObject> GoodsAsync;

    /// <summary>
    /// 实例化的工具
    /// </summary>
    public GameObject GoodsObject
    {
        get { return Goods; }
    }

    /// <summary>
    /// 委托
    /// </summary>
    private Action CompletedAction = null;


    /// <summary>
    /// 工具的预加载
    /// </summary>
    /// <param name="goodsKeys"></param>
    public void LoadGoodsAsset(string  goodsKeys, Action action = null)
    {
        Debug.Log("预加载工具Key值：" + goodsKeys);
        CompletedAction = action;
        Addressables.LoadAssetAsync<GameObject>(goodsKeys).Completed += Goods_Completed;
       
    }
    /// <summary>
    /// 工具预加载成功
    /// </summary>
    /// <param name="obj"></param>
    private void Goods_Completed(AsyncOperationHandle<GameObject> obj)
    {
        if (GoodsAsync.IsValid()) Addressables.Release(GoodsAsync);

        GoodsAsync = obj;
        GoodsAsset = obj.Result;
        Debug.Log("工具预加载完成" + GoodsAsset.name);

        CompletedAction?.Invoke();
    }
    /// <summary>
    /// 工具 创建
    /// </summary>
    /// <returns></returns>
    public GameObject InstantiateGoods(Transform parentTransform,string name)
    {
        Goods = GameObject.Instantiate(GoodsAsset, parentTransform);
        Goods.name = name;
        return Goods;
    }

    public void DeleteGoods()
    {
        GameObject.Destroy(Goods);
    }
}

