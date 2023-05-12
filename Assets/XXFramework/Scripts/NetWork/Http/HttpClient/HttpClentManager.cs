using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class HttpClentManager : UnitySingletonDestoryOnload<HttpClentManager>
{

    private readonly HttpClient _httpClient = null;
    public HttpClentManager()
    {
        _httpClient = new HttpClient();
        _httpClient.MaxResponseContentBufferSize = 256000;
        _httpClient.Timeout = TimeSpan.FromMilliseconds(15000);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Get(string url, Action<string> _onHttpReceive = null)
    {
        try
        {
            var responseString = _httpClient.GetStringAsync(url);
            if (responseString != null && _onHttpReceive != null)
            {
                _onHttpReceive?.Invoke(responseString.Result.ToString());
            }
        }
        catch (Exception ex)
        {
            DebugLogController.Error("Get请求异常" + ex);
        }
    }

    public void Post(string url,string strJson)
    {
        try
        {
            HttpContent content = new StringContent(strJson);
            Task<HttpResponseMessage> res = _httpClient.PostAsync(url, content);
            Debug.Log(res.Result.StatusCode);
            string str = res.Result.Content.ReadAsStringAsync().Result;
            if (res.Result.StatusCode == HttpStatusCode.OK)
            {
                Debug.Log(str);
            }
            else
            {
                if (res.Result.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    Debug.LogWarning("request time out !");
                }

            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);

        }
    }
    public async Task GetAsync(string url, Action<string> _onHttpReceive = null)
    {
        try
        {
            var responseString = await _httpClient.GetStringAsync(url);
            Debug.Log(responseString);
            if (responseString != null && _onHttpReceive != null)
            {
                _onHttpReceive?.Invoke(responseString.ToString());
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Get异常" + ex);
        }
    }
    public async Task<string> PostAsync(string url, string strJson)
    {
        try
        {
            HttpContent content = new StringContent(strJson);
            HttpResponseMessage res = await _httpClient.PostAsync(url, content);
            Debug.Log(res.StatusCode);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                string str = res.Content.ReadAsStringAsync().Result;
                return str;
            }
            else
            {
                if (res.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    Debug.LogWarning("request time out !");
                }
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }
}
