using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    
    public WebSocketClient webSocketClient;
    
    // Start is called before the first frame update
    private void Start()
    {
        webSocketClient = GameObject.Find("WebSocketManager").GetComponent<WebSocketClient>();
    }

    // Update is called once per frame
    private void Update()
    {
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("======OnCollisionEnter: "+ other.gameObject.tag);
        // 
        if (!other.gameObject.CompareTag("Ground"))
        {  
          webSocketClient.SendWebSocketMessage("VIBRATE LEFT:1000");
          
        }
    }
}