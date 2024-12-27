using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string promptWithoutKey = "No key found";

    [SerializeField] private string promptWithKey = "Press [E] to open door";

    [SerializeField] private GameObject houseDoorCollider;

    private AudioSource doorAudioSource;

    private bool isClosed = true;

    public string InteractionPrompt
    {
        get
        {
            if (!isClosed)
            {
                // No prompt if the door is already open
                return ""; 
            }
            // Check if the interactor (player) has the key
            var interactor = FindObjectOfType<Interactor>();
            var inventory = interactor?.GetComponent<Inventory>();

            if (inventory != null && inventory.hasMainDoorKey)
            {
                return promptWithKey;
            }
            else
            {
                return promptWithoutKey;
            }
        }
    }

    public bool Interact(Interactor interactor)
    {
        // If the door is opened, dont execute
        if (!isClosed) return false;

        var gameObjectName = this.name;
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.hasMainDoorKey)
        {
            // Open the door
            OpenDoor();
            isClosed = false;
            Debug.Log("Opening door " + gameObjectName);
            return true;
        }
        else
        {
            // Don't have the key to open door
            Debug.Log("No key found");
            return false;
        }
    }

    private void OpenDoor()
    {
        doorAudioSource = GetComponent<AudioSource>();
        // Play the door opening sound
        if (doorAudioSource != null && !doorAudioSource.isPlaying)
        {
            doorAudioSource.Play();
        }

        // Target rotation: Y-axis from -180 to -80
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -80, transform.rotation.eulerAngles.z);

        // Start the rotation coroutine
        StartCoroutine(RotateDoor(targetRotation));

        // Disable the collider
        if (houseDoorCollider != null)
        {
            houseDoorCollider.SetActive(false);
        }
    }

    private IEnumerator RotateDoor(Quaternion targetRotation)
    {
        float rotationSpeed = 2f; 
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null; // Wait for the next frame
        }

        // Ensure the door snaps to the exact target rotation at the end
        transform.rotation = targetRotation;
    }

    void Start()
    {
        isClosed = true;
        houseDoorCollider.SetActive(true);
    }

    void Update()
    {
    }
}