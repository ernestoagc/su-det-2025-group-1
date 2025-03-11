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


    private bool isPlayingLevel1 = false;
    private bool isPlayingLevel2 = false;
    private bool isPlayingLevel3 = false;

    void Start()
    {
        if (playSoundButton1 != null)
        {
            playSoundButton1.onClick.AddListener(() => ToggleSound(level1, ref isPlayingLevel1));
        }

        if (playSoundButton2 != null)
        {
            playSoundButton2.onClick.AddListener(() => ToggleSound(level2, ref isPlayingLevel2));
        }

        if (playSoundButton3 != null)
        {
            playSoundButton3.onClick.AddListener(() => ToggleSound(level3, ref isPlayingLevel3));
        }
    }

    void ToggleSound(GameObject[] soundGroup, ref bool isPlaying)
    {
        if (isPlaying)
        {
            StopSoundGroup(soundGroup);
        }
        else
        {
            PlaySoundGroup(soundGroup);
        }

        isPlaying = !isPlaying;
    }

    void PlaySoundGroup(GameObject[] soundGroup)
    {
        foreach (GameObject obj in soundGroup)
        {
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    void StopSoundGroup(GameObject[] soundGroup)
    {
        foreach (GameObject obj in soundGroup)
        {
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
