using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NativeWebSocket;
public class WebSocketClient : MonoBehaviour
{
    public GameManager gameManager;
    
    [SerializeField] private string IPAdress = "10.93.102.170"; //The IP Adress of the Server you want to connect to

    [SerializeField] private int Port = 3000; //The Port your WebSocket Connection will "talk" to

    private WebSocket webSocket;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        initWebSocket();
    }

    // Update is called once per frame
    private void Update()
    {
       webSocket.DispatchMessageQueue();
    }


    private async void OnApplicationQuit() //Closes Websocket Connection Correctly when app is closed
    {
        await webSocket.Close();
    }

    private void initWebSocket() //Starts WebSocket Client Connection
    {
        webSocket = new WebSocket($"ws://{IPAdress}:{Port}");
        webSocket.Connect();
        //await Task.Delay(100);
        
       
        webSocket.OnOpen += WebSocket_OnOpen;
        webSocket.OnError += WebSocket_OnError;
        webSocket.OnClose += WebSocket_OnClose;
        webSocket.OnMessage += WebSocket_OnMessage;
    }

    private void WebSocket_OnMessage(byte[] data, int offset, int length)
    {
        throw new System.NotImplementedException();
    }

    private void WebSocket_OnOpen() //Alerts on console when WebSocket Connection is Successfull
    {
        Debug.Log("Connecion opened!");
        var message = "Hello from Unity! = Device name: " + SystemInfo.deviceName + " | Device Mac Address: " +
                      SystemInfo.deviceUniqueIdentifier;
        SendWebSocketMessage(message);
    }

    private void WebSocket_OnError(string error) //Alerts on console when WebSocket Connection is Unsuccessfull
    {
        Debug.Log($"Error: {error}");
    }

    private void WebSocket_OnClose(WebSocketCloseCode closeCode) //Alerts on console when WebSocket Connection is Closed
    {
        Debug.Log("Connection closed!");
    }

    private void
        WebSocket_OnMessage(
            byte[] data) //Receives webSocket message and handles it respectively depending on what it contains
    {
        var socketMessage = Encoding.UTF8.GetString(data);
        //Debug.Log(System.Text.Encoding.UTF8.GetString(data));

        if (socketMessage.Contains("EMERGENCY BUTTON PRESSED") && !gameManager.isSafePlace)
        {
            Debug.Log("====>Presionando boton Emergencia===!");
            
            gameManager.MoveToSafeEnvironment();
        }
        {
         //   Debug.Log("OnMessage!");

        };
    }


    public async void SendWebSocketMessage(string text) //Sends Websocket Message to Server for the ESP32 to receive
    {
        Debug.Log("Sending message to server: " + text);

        if (webSocket.State == WebSocketState.Open)
            // Sending plain text socket
            await webSocket.SendText(text);
    }

    
}