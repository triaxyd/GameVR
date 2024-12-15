using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorKey : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    // Reference to the AudioSource component
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] public string InteractionPrompt => _prompt;

    // Prevent multiple presses
    private bool playerPressedKey = false;

    public bool Interact(Interactor interactor)
    {
        if (playerPressedKey) return false;

        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        // Player pressed to pick key
        playerPressedKey = true;

        // Set the hasMainDoorKey boolean to True -> Player got the key
        inventory.hasMainDoorKey = true;

        // Play the sound
        if (_audioSource != null)
        {
            _audioSource.Play();
            StartCoroutine(StopSoundAfterDuration(0.5f)); // Stop after 0.5 seconds
        }

        // Hide the Key immediately
        StartCoroutine(HideKeyAfterSound());

        Debug.Log("Got the door key");

        return true;
    }

    private IEnumerator StopSoundAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        _audioSource.Stop(); // Stop the sound early
    }

    private IEnumerator HideKeyAfterSound()
    {
        // Short wait for the sound effect, in case StopSoundAfterDuration hasn't finished
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }

    void Start()
    {
        gameObject.SetActive(true);

        // Ensure the AudioSource is assigned
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }

   
}
