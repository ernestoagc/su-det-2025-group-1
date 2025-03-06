using System.Text;
using UnityEngine;
using Meta.Net.NativeWebSocket;
public class Connection : MonoBehaviour
{
    private WebSocket websocket;

    // Start is called before the first frame update
    private async void Start()
    {
        // websocket = new WebSocket("ws://echo.websocket.org");
        websocket = new WebSocket("ws://localhost:3000");

        websocket.OnOpen += () => { Debug.Log("Connection open!"); };

        websocket.OnError += e => { Debug.Log("Error! " + e); };

        websocket.OnClose += e => { Debug.Log("Connection closed!"); };

        websocket.OnMessage += WebSocket_OnMessage;

        // Keep sending messages at every 0.3s
        InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

        await websocket.Connect();
    }

    private void WebSocket_OnMessage(byte[] data, int offset, int length)
    {
        throw new System.NotImplementedException();
    }

    public void
        WebSocket_OnMessage(
            byte[] data) //Receives webSocket message and handles it respectively depending on what it contains
    {
    }

    private void Update()
    {
        
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }

    private async void SendWebSocketMessage()
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Sending bytes
            await websocket.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            await websocket.SendText("plain text message");
        }
    }
}