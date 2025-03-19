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

    private int currentLevel;
    
    private bool isPlaying = false;  // Track if any sound is playing
    private Button activeButton = null; // Track currently active button

    void Start()
    {
        currentLevel = 0;
        // Optional: Auto-assign button listeners (useful if not assigned manually in Unity Editor)
        if (playSoundButton1 != null)
        {
            playSoundButton1.onClick.AddListener(() => OnButtonClicked(1));
        }

        if (playSoundButton2 != null)
        {
            playSoundButton2.onClick.AddListener(() => OnButtonClicked(2));
        }

        if (playSoundButton3 != null)
        {
            playSoundButton3.onClick.AddListener(() => OnButtonClicked(3));
        }
    }
    
    public void ChangeSoundLevel()
    {
        if (currentLevel > 3)
            currentLevel = 0;

        currentLevel++;
        OnButtonClicked(currentLevel);
    }

    // Public method to assign in the Unity Editor
    public void OnButtonClicked(int level)
    {
        if (level == 1) ToggleSound(level1, playSoundButton1);
        else if (level == 2) ToggleSound(level2, playSoundButton2);
        else if (level == 3) ToggleSound(level3, playSoundButton3);
    }

    void ToggleSound(GameObject[] soundGroup, Button clickedButton)
    {
        StopAllSounds(); // Stop all sounds before playing the new one
        PlaySoundGroup(soundGroup);
        isPlaying = true;
       // activeButton = clickedButton;
        //DisableOtherButtons(clickedButton);
    }

    /*
    void ToggleSound(GameObject[] soundGroup, Button clickedButton)
    {
        if (isPlaying && activeButton == clickedButton) // If the same button is clicked again, turn it off
        {
            StopAllSounds();
            isPlaying = false;
            activeButton = null;
            EnableAllButtons();
        }
        else
        {
            StopAllSounds(); // Stop all sounds before playing the new one
            PlaySoundGroup(soundGroup);
            isPlaying = true;
            activeButton = clickedButton;
            DisableOtherButtons(clickedButton);
        }
    }
*/
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
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void DisableOtherButtons(Button active)
    {
        if (playSoundButton1 != active) playSoundButton1.interactable = false;
        if (playSoundButton2 != active) playSoundButton2.interactable = false;
        if (playSoundButton3 != active) playSoundButton3.interactable = false;
    }

    void EnableAllButtons()
    {
        playSoundButton1.interactable = true;
        playSoundButton2.interactable = true;
        playSoundButton3.interactable = true;
    }
}