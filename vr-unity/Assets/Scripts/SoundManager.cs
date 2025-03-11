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
            playSoundButton1.onClick.AddListener(() => ToggleSound(level1, ref isPlayingLevel1, playSoundButton1, playSoundButton2, playSoundButton3));
        }

        if (playSoundButton2 != null)
        {
            playSoundButton2.onClick.AddListener(() => ToggleSound(level2, ref isPlayingLevel2, playSoundButton2, playSoundButton1, playSoundButton3));
        }

        if (playSoundButton3 != null)
        {
            playSoundButton3.onClick.AddListener(() => ToggleSound(level3, ref isPlayingLevel3, playSoundButton3, playSoundButton1, playSoundButton2));
        }
    }

    void ToggleSound(GameObject[] soundGroup, ref bool isPlaying, Button activeButton, Button button1, Button button2)
    {
        if (isPlaying)
        {
            StopSoundGroup(soundGroup);
            EnableButtons(button1, button2); // Re-enable other buttons
        }
        else
        {
            StopAllSounds(); // Ensure only one group plays at a time
            PlaySoundGroup(soundGroup);
            DisableButtons(button1, button2); // Disable other buttons
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

    public void StopAllSounds()
    {
        StopSoundGroup(level1);
        StopSoundGroup(level2);
        StopSoundGroup(level3);
        EnableButtons(playSoundButton1, playSoundButton2, playSoundButton3); // Re-enable all buttons
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
