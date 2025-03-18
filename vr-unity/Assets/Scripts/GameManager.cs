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

    public void AddCube()
    {
        float distance = Random.Range(0f, 1.2f);
        float xPosition = -0.44f +distance;
        // float xPosition = -1.2f +distance;
        Vector3 spawnPos = new Vector3(xPosition, 1.3f, 0.369f);
        
        //  transform.Rotate(0f, 0f, 0f);
        //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            
       // Instantiate(cubeObstacle, spawnPos,Quaternion.Euler(0f, 0f, 0f));
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
