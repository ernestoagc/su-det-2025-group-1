using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedLoopAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayBetweenLoops = 2f;
    private bool isPlaying = false;

    public void StartAudioLoop()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            StartCoroutine(PlayAudioWithDelay());
        }
    }

    public void StopAudioLoop()
    {
        isPlaying = false;
        StopCoroutine(PlayAudioWithDelay());
        audioSource.Stop();
    }

    IEnumerator PlayAudioWithDelay()
    {
        while (isPlaying)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length + delayBetweenLoops);
        }
    } 
}
