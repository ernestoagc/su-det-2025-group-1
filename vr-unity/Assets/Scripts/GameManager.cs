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
    
    public void AddCube()
    {
        float distance = Random.Range(0f, 1.2f);
        float xPosition = -0.44f +distance;
        // float xPosition = -1.2f +distance;
        Vector3 spawnPos = new Vector3(xPosition, 1.3f, 0.369f);
        
        //  transform.Rotate(0f, 0f, 0f);
        //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            
        Instantiate(cubeObstacle, spawnPos,Quaternion.Euler(0f, 0f, 0f));
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
