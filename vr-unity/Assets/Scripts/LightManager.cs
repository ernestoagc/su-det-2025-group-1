using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class LightManager : MonoBehaviour
{
    public GameObject[] level1Lights;
    public GameObject[] level2Lights;
    public GameObject[] level3Lights;

    public Button lightButton1;
    public Button lightButton2;
    public Button lightButton3;

    private Button activeButton = null;
    private GameObject[] activeLightGroup = null;

    void Start()
    {
        if (lightButton1 != null)
        {
            lightButton1.onClick.AddListener(() => OnLightButtonClicked(lightButton1, level1Lights));
        }

        if (lightButton2 != null)
        {
            lightButton2.onClick.AddListener(() => OnLightButtonClicked(lightButton2, level2Lights));
        }

        if (lightButton3 != null)
        {
            lightButton3.onClick.AddListener(() => OnLightButtonClicked(lightButton3, level3Lights));
        }
    }


    void OnLightButtonClicked(Button clickedButton, GameObject[] lightGroup)
    {
        bool isTurningOn = (activeButton != clickedButton); 
   

        if (isTurningOn)
        {
            
            if (activeLightGroup != null)
            {
              
                ToggleLightGroup(activeLightGroup, false);
            }

           
            activeButton = clickedButton;
            activeLightGroup = lightGroup;
            DisableOtherButtons(clickedButton);

         
            ToggleLightGroup(lightGroup, true);
        }
        else
        {
           
            activeButton = null;
            activeLightGroup = null;
            EnableAllButtons();
         
            ToggleLightGroup(lightGroup, false);
        }
    }

    
    void ToggleLightGroup(GameObject[] lightGroup, bool state)
    {
        foreach (GameObject obj in lightGroup)
        {
            
            LightFlickr flickerScript = obj.GetComponent<LightFlickr>();
            if (flickerScript != null)
            {
                flickerScript.ToggleLight(state);
            }

              Light lightComponent = obj.GetComponent<Light>();
            if (lightComponent != null)
            {
                lightComponent.enabled = state;
            }
        }
    }

 
    void DisableOtherButtons(Button active)
    {
        if (lightButton1 != active) lightButton1.interactable = false;
        if (lightButton2 != active) lightButton2.interactable = false;
        if (lightButton3 != active) lightButton3.interactable = false;
    }

   
    void EnableAllButtons()
    {
        lightButton1.interactable = true;
        lightButton2.interactable = true;
        lightButton3.interactable = true;
    }
}
