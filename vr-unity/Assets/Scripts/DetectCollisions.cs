using UnityEngine;
using UnityEngine.SceneManagement;
public class DetectCollisions : MonoBehaviour
{
    
    public WebSocketClient webSocketClient;
    public GameManager gameManager;
    
        
    
    // Start is called before the first frame update
    private void Start()
    {
        webSocketClient = GameObject.Find("WebSocketManager").GetComponent<WebSocketClient>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("======OnCollisionEnter: "+ other.gameObject.tag);
        
        if (other.gameObject.CompareTag("Person"))
        {   
            gameManager.SendVibration();
            gameManager.SendVibrationRight();
         // webSocketClient.SendWebSocketMessage("VIBRATE LEFT:1000");
          
        }
    }
}