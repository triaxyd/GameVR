using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour, IInteractable
{
    // The prompt displayed
    [SerializeField] private string _prompt;

    // Reference to the AudioSource component
    [SerializeField] private AudioSource _audioSource;

    // Interaction prompt inherited 
    [SerializeField] public string InteractionPrompt => _prompt;

    // Prevent multiple presses
    private bool playerPressedKey = false;

    // Implementation of Interact of interactable
    public bool Interact(Interactor interactor)
    {
        if (playerPressedKey) return false;

        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        // Player pressed to pick Pumpkin
        playerPressedKey = true;

        // Set the hasPumpkin boolean to True -> Player got pumpkin
        inventory.hasPumpkin = true;

        // Play the sound
        if (_audioSource != null)
        {
            _audioSource.Play();
            StartCoroutine(StopSoundAfterDuration(0.5f)); // Stop after 0.5 seconds
        }

        // Hide pumpkin immediately
        StartCoroutine(HidePumpkinAfterSound());

        Debug.Log("Got pumpkin");

        return true;
    }

    private IEnumerator StopSoundAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        _audioSource.Stop(); // Stop the sound early
    }

    private IEnumerator HidePumpkinAfterSound()
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
