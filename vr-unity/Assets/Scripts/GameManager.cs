using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool showUpCube;
    public bool enableWalk = true;
    public bool isSafePlace = false;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        isSafePlace = false;
    }

    public void MoveToSafeEnvironment()
    {
        isSafePlace = true;
        SceneManager.LoadScene("safety-environment");
    }

    public void EnableWalk()
    {
        enableWalk = true;
    }
    
    public void DisableWalk()
    {
        enableWalk = false;
    }

    public void ChangeWalkMode()
    {
        enableWalk = !enableWalk;
    }
    
    public void ChangeLightModeManager()
    {
        enableWalk = !enableWalk;
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
        WebSocketClient.Instance.SendWebSocketMessage("VIBRATE LEFT:1000");
    }
    
    public void SendVibrationRight()
    {
        Debug.Log("Calling method ..SendVibrationRight");
        WebSocketClient.Instance.SendWebSocketMessage("VIBRATE RIGHT:1000");
    }
}
