using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool showUpCube;
    public bool enableWalk = true;
    public bool isSafePlace = false;
    public bool isStartEnvironment = true;

    public GameObject disclaimerText;
    public GameObject MenuIntroductionText;
    
    // Start is called before the first frame update
    void Start()
    {
        isSafePlace = false;
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
    
    public void MoveToDesignEnvironment()
    {
        isStartEnvironment = false;
        SceneManager.LoadScene("design-environment");
    }
    
    public void ContinueInStartEnvironment()
    {
        disclaimerText.SetActive(false);
        MenuIntroductionText.SetActive(true);
    }
    
    public void EnableWalk()
    {
        enableWalk = true;
    }
    
    public void EnableStartEnvironment()
    {
        isStartEnvironment = true;
    }
    
    public void DisableStartEnvironment()
    {
        isStartEnvironment = false;
    }

   public void DisableWalk()
    {
        enableWalk = false;
    }

    public void ChangeWalkMode()
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
