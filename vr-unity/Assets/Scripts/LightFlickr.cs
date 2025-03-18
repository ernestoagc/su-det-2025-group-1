using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LightFlickr : MonoBehaviour
{
    private Light flickerLight;
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;

    private bool isLightOn = false; 

    void Start()
    {
        flickerLight = GetComponent<Light>();
        if (flickerLight == null)
        {
            enabled = false; 
        }
        else
        {
          
            flickerLight.intensity = 0f;
            flickerLight.enabled = false;  
        }
    }

    void Update()
    {
        if (isLightOn) 
        {
            
            float intensity = UnityEngine.Random.value > 0.1f ? UnityEngine.Random.Range(minIntensity, maxIntensity) : 0f;
            flickerLight.intensity = intensity;
        }
    }

  
    public void ToggleLight(bool state)
    {
        
        isLightOn = state;

        
        flickerLight.enabled = state;  
        flickerLight.intensity = state ? maxIntensity : 0f; 
    }
}
