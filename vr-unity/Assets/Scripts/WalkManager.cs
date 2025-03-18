using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkManager : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
    
    private void OnCollisionEnter(Collision other)
    {
       if (!other.gameObject.CompareTag("Ground"))
       {
           ChangeWalkingRotation();
           // webSocketClient.SendWebSocketMessage("VIBRATE LEFT:1000");

       }
    }

    public void ChangeWalkingRotation()
    {
       transform.Rotate(0 , 50f ,0);
    }



}
