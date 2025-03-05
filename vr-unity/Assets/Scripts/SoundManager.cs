using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public GameObject[] level1;
    public GameObject[] level2;
    public GameObject[] level3;

    public Button playSoundButton1;
    public Button playSoundButton2;
    public Button playSoundButton3;

    void Start()
    {
        if (playSoundButton1 != null)
        {
            playSoundButton1.onClick.AddListener(() => OnPlaySoundButtonClicked(level1));
        }

        if (playSoundButton2 != null)
        {
            playSoundButton2.onClick.AddListener(() => OnPlaySoundButtonClicked(level2));
        }

        if (playSoundButton3 != null)
        {
            playSoundButton3.onClick.AddListener(() => OnPlaySoundButtonClicked(level3));
        }
    }

    void OnPlaySoundButtonClicked(GameObject[] soundGroup)
    {
        foreach (GameObject obj in soundGroup)
        {
   
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    public void StopAllSounds()
    {
        StopSoundGroup(level1);
        StopSoundGroup(level2);
        StopSoundGroup(level3);
    }

    void StopSoundGroup(GameObject[] soundGroup)
    {
        foreach (GameObject obj in soundGroup)
        {
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }
}
