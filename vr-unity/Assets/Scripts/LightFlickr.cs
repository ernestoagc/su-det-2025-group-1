using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LightFlickr : MonoBehaviour
{
    private Light flickerLight;
    public float minIntensity = 0.1f;
    public float maxIntensity = 2.5f;
    public float flickerSpeed = 0.05f;

    void Start()
    {
        flickerLight = GetComponent<Light>();
        if (flickerLight == null)
        {
            //Debug.LogError("No Light component found on " + gameObject.name);
            enabled = false;
        }
    }

    void Update()
    {
        flickerLight.intensity = UnityEngine.Random.Range(minIntensity, maxIntensity);
    }
}
