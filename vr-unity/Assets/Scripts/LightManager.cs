using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LightManager : MonoBehaviour
{
    public GameObject[] lightGroup1;
    public GameObject[] lightGroup2;
    public GameObject[] lightGroup3;

    public Button toggleLightButton1;
    public Button toggleLightButton2;
    public Button toggleLightButton3;

    private bool isGroup1On = false;
    private bool isGroup2On = false;
    private bool isGroup3On = false;

    void Start()
    {
        if (toggleLightButton1 != null)
        {
            toggleLightButton1.onClick.AddListener(() => ToggleLights(lightGroup1, ref isGroup1On));
        }

        if (toggleLightButton2 != null)
        {
            toggleLightButton2.onClick.AddListener(() => ToggleLights(lightGroup2, ref isGroup2On));
        }

        if (toggleLightButton3 != null)
        {
            toggleLightButton3.onClick.AddListener(() => ToggleLights(lightGroup3, ref isGroup3On));
        }
    }

    void ToggleLights(GameObject[] lightGroup, ref bool isOn)
    {
        foreach (GameObject obj in lightGroup)
        {
            Light light = obj.GetComponent<Light>();
            if (light != null)
            {
                light.enabled = !isOn;
            }
        }
        isOn = !isOn;
    }
}
