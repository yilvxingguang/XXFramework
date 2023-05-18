using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class WebSocketManager : MonoBehaviour
{
    private ClientWebSocket _ws;
    private byte[] _receiveBuff;
    private byte[] _sendBuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async Task Connect(string Url)
    {
        try
        {
            _ws = new ClientWebSocket();
 
            await _ws.ConnectAsync(new Uri(Url), CancellationToken.None);
          
            await Task.WhenAll(Receive(_ws), Send(_ws));
        }
        catch (Exception e)
        {
            // ignored
            Debug.LogError("ASR连接错误" + e);
        }
        finally
        {
            if (_ws != null)
            {
                _ws.Dispose();
                _ws = null;
            }
        }
    }
    private async Task Receive(ClientWebSocket webSocket)
    {
        while (webSocket.State == WebSocketState.Open)
        {

            Array.Clear(_receiveBuff, 0, _receiveBuff.Length);
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(_receiveBuff), CancellationToken.None);
            Debug.Log("Receive的消息类型:" + result.MessageType);
            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
            else
            {

            }
        }
    }
    private async Task Send(ClientWebSocket webSocket)
    {
        while (webSocket is { State: WebSocketState.Open })
        {
            await webSocket.SendAsync(new ArraySegment<byte>(_sendBuff),
                                      WebSocketMessageType.Binary,
                                      true, CancellationToken.None);
        }
    }


}
