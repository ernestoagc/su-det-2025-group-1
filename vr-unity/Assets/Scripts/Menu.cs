using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandMenu : MonoBehaviour
{
   private bool isPaused;
   private LightManager lightManager;
   private SoundManager soundManager;
   public TextMeshProUGUI txtWalk;

   // Start is called before the first frame update
   void Start()
   {
      lightManager = GameObject.Find("LightManager").GetComponent<LightManager>();
      soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void ChangeWalkMode()
   {
      GameManager.Instance.ChangeWalkMode();
      txtWalk.text= GameManager.Instance.enableWalk ? "1" : "0";
   }
   public void ChangeLightMode()
   {
      lightManager.ChangeLightLevel();
      txtWalk.text = lightManager.currentLevel.ToString();
   }
   
   public void ChangeSoundMode()
   {
      soundManager.ChangeSoundLevel();
      txtWalk.text = soundManager.currentLevel.ToString();
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
      GameManager.Instance.isSafePlace = false;
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
