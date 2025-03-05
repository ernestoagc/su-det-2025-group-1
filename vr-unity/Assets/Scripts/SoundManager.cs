using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Arrays to hold different groups of game objects with audio sources
    public GameObject[] level1;
    public GameObject[] level2;
    public GameObject[] level3;

    // Buttons to trigger sound play
    public Button playSoundButton1;
    public Button playSoundButton2;
    public Button playSoundButton3;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the buttons are set and add listeners to each button
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

    // This function will be triggered when any button is clicked
    void OnPlaySoundButtonClicked(GameObject[] soundGroup)
    {
        // Play the sounds of the selected sound group
        foreach (GameObject obj in soundGroup)
        {
            // Ensure the object has an AudioSource component
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                // Play the sound at the object's position
                audioSource.Play();
            }
        }
    }

    // Optionally, add a function to stop all sounds from all groups
    public void StopAllSounds()
    {
        StopSoundGroup(level1);
        StopSoundGroup(level2);
        StopSoundGroup(level3);
    }

    // Function to stop sounds in a specific group
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
