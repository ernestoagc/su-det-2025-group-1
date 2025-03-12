using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickr : MonoBehaviour
{
    private Light flickerLight;
    public float minIntensity = 0.2f; 
    public float maxIntensity = 1.5f; 
    public float flickerSpeed = 0.1f;

    void Start()
    {
        flickerLight = GetComponent<Light>();
    }

    void Update()
    {
        if (flickerLight != null)
        {
            flickerLight.intensity = UnityEngine.Random.Range(minIntensity, maxIntensity);
            flickerLight.enabled = (UnityEngine.Random.value > 0.1f);
        }
    }
}
