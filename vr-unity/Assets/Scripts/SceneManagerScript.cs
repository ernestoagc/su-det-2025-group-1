using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void NavigateToPocGrab()
    {
      SceneManager.LoadScene("poc-grab");
    }

     public void NavigateToPocMenu()
    {
      SceneManager.LoadScene("poc-menu");
    }

   public void NavigateToSafetyEnvironment()
   {
      SceneManager.LoadScene("safety-environment");
   }

   public void NavigateToStartupEnvironment()
    {
      SceneManager.LoadScene("startup-environment");
    }

   public void NavigateToDesignEnvironment()
    {
      SceneManager.LoadScene("design-environment");
    }

}
