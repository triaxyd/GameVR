using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // Automatically get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource is missing on: " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger and the sound is not already playing
        if (other.CompareTag("Player") && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop playing the sound when the player leaves the trigger
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}