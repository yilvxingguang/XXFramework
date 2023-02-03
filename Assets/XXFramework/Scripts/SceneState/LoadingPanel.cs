using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    public ISceneState SceneSate;
    private Slider loadingSlider;
    private void Start()
    {
        StartCoroutine(LoadScene());//协程运行，加载场景
    }
    IEnumerator LoadScene()//异步加载场景
    {

      SceneStateController.Instance.asyncOperation = SceneManager.LoadSceneAsync(SceneSate.sceneName);//在后台异步加载一个场景并且赋值给场景状态控制器的asyncOperation
        SceneStateController.Instance.asyncOperation.allowSceneActivation = false;  //先不切换场景，allowSceneActivation决定是否切换场景
        // 生成loading界面
        loadingSlider = transform.GetComponentInChildren<Slider>();//将资源加载时间和Loading界面的Slider关联起来
        loadingSlider.value = 0;//Slider初始值为0

        while (SceneStateController.Instance.asyncOperation.progress < 0.89)//当场景异步加载进度小于0.89
        {
            while (SceneStateController.Instance.asyncOperation.progress > loadingSlider.value)//场景异步加载进度大于加载进度条的值
            {
         //      Debug.Log(loadingSlider.value);
                loadingSlider.value += 0.01f;
                yield return new WaitForEndOfFrame();//协程启动
            }
            yield return new WaitForEndOfFrame();
        }
        while (loadingSlider.value < 1)
        {
            loadingSlider.value += 0.01f;
            yield return new WaitForEndOfFrame();
        }
        SceneStateController.Instance.asyncOperation.allowSceneActivation = true;  //切换场景
        yield return new WaitForEndOfFrame();
    }

}

