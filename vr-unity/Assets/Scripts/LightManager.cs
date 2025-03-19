using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class LightManager : MonoBehaviour
{
    public GameObject[] lights1;
    public GameObject[] lights2;
    public GameObject[] lights3;

    public Button lightButton1;
    public Button lightButton2;
    public Button lightButton3;

    private bool isLights1On = false;
    private bool isLights2On = false;
    private bool isLights3On = false;
    
    private int currentLevel = 0;

    void Start()
    {
        if (lightButton1 != null)
            lightButton1.onClick.AddListener(() => OnButtonClicked(1));

        if (lightButton2 != null)
            lightButton2.onClick.AddListener(() => OnButtonClicked(2));

        if (lightButton3 != null)
            lightButton3.onClick.AddListener(() => OnButtonClicked(3));
    }

    public void OnButtonClicked(int buttonIndex)
    {
        if (buttonIndex == 1)
            ToggleLights(lights1, ref isLights1On, lightButton1, lightButton2, lightButton3);
        else if (buttonIndex == 2)
            ToggleLights(lights2, ref isLights2On, lightButton2, lightButton1, lightButton3);
        else if (buttonIndex == 3)
            ToggleLights(lights3, ref isLights3On, lightButton3, lightButton1, lightButton2);
    }

    public void ChangeLightLevel()
    {
        if (currentLevel > 3)
            currentLevel = 0;

        currentLevel++;
        OnButtonClicked(currentLevel);
    }
    

    void ToggleLights(GameObject[] lightGroup, ref bool isOn, Button activeButton, Button button1, Button button2)
    {
        if (isOn)
        {
            SetLights(lightGroup, false);
            EnableButtons(button1, button2);
        }
        else
        {
            TurnOffAllLights();
            SetLights(lightGroup, true);
            DisableButtons(button1, button2);
        }
        isOn = !isOn;
    }

    void SetLights(GameObject[] lightGroup, bool state)
    {
        foreach (GameObject obj in lightGroup)
        {
            Light light = obj.GetComponent<Light>();
            if (light != null)
            {
                light.enabled = state;
            }
        }
    }

    public void TurnOffAllLights()
    {
        SetLights(lights1, false);
        SetLights(lights2, false);
        SetLights(lights3, false);
        EnableButtons(lightButton1, lightButton2, lightButton3);
    }

    void DisableButtons(Button button1, Button button2)
    {
        button1.interactable = false;
        button2.interactable = false;
    }

    void EnableButtons(Button button1, Button button2)
    {
        button1.interactable = true;
        button2.interactable = true;
    }

    void EnableButtons(Button button1, Button button2, Button button3)
    {
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
    }
}
