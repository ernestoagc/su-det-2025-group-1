using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandMenu : MonoBehaviour
{
   private bool isPaused;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public void TogglePause()
   {
      isPaused = !isPaused;

      GameObject menuCanvas = this.gameObject.transform.Find("MenuCanvas").gameObject;
      menuCanvas.SetActive(isPaused);
      // Time.timeScale = isPaused ? 0 : 1;
   }

   public void NavigateToDesignEnvironment()
   {
      SceneManager.LoadScene("design-environment");
   }

   public void StartExperience()
   {
      StartCoroutine(DelayAction(4));
   }

   IEnumerator DelayAction(float delayTime)
   {
      yield return new WaitForSeconds(delayTime);

      NavigateToDesignEnvironment();
   }
}
