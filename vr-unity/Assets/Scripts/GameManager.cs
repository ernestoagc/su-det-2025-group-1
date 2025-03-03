using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public WebSocketClient webSocketClient;
    public GameObject cubeObstacle;
    private bool showUpCube;
    
    // Start is called before the first frame update
    void Start()
    {
        showUpCube = false;
        webSocketClient = GameObject.Find("WebSocketManager").GetComponent<WebSocketClient>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowCube()
    {
        if (!showUpCube)
        {
            cubeObstacle.SetActive(true);
            showUpCube = true;
        }
        
    }
    
    public void RestartGame()
    {
        showUpCube = false;
        cubeObstacle.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SendVibration()
    {
        webSocketClient.SendWebSocketMessage("VIBRATE LEFT:1000");
    }
}
