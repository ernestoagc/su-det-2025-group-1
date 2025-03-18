using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public WebSocketClient webSocketClient;
    private bool showUpCube;
    public bool isSafePlace = false;
    
    // Start is called before the first frame update
    void Start()
    {
        isSafePlace = false;
        webSocketClient = GameObject.Find("WebSocketManager").GetComponent<WebSocketClient>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSafeEnvironment()
    {
        isSafePlace = true;
        SceneManager.LoadScene("safety-environment");
    }

    
    public void RestartGame()
    {
        Debug.Log("Calling method ..RestartGame");
        isSafePlace = false;
        SceneManager.LoadScene("design-environment");
    }

    public void SendVibration()
    {
        Debug.Log("Calling method ..SendVibration");
        webSocketClient.SendWebSocketMessage("VIBRATE LEFT:1000");
    }
    
    public void SendVibrationRight()
    {
        Debug.Log("Calling method ..SendVibrationRight");
        webSocketClient.SendWebSocketMessage("VIBRATE RIGHT:1000");
    }
}
