using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBase : MonoBehaviour, IInteractable
{
    
    [SerializeField] protected string promptTask = "I have a task for you!";
    [SerializeField] protected string promptTaskCompleted = "Thanks for completing my task!";
    [SerializeField] protected float interactionRange = 3f;

    
    [SerializeField] protected Transform headTransform;
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected float maxLookAngle = 80f;
    //[SerializeField] protected float lookAtDuration = 0.5f; 

    protected bool completedTask = false;

    public abstract string InteractionPrompt { get; }

    public abstract bool Interact(Interactor interactor);

    void Update()
    {
        // Check if the player is in range
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= interactionRange)
        {
            LookAtPlayer();
        }
    }

    private void LookAtPlayer()
    {
        // Get the direction to the player
        Vector3 directionToPlayer = playerTransform.position - headTransform.position;

        // Remove vertical tilt (optional)
        directionToPlayer.y = 0;

        // Check if the player is close enough to interact
        if (directionToPlayer.magnitude <= interactionRange)
        {
            // Calculate the target rotation toward the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer.normalized);

            // Clamp the rotation
            Quaternion clampedRotation = ClampRotation(headTransform.rotation, targetRotation, maxLookAngle);

            // Apply the clamped rotation
            headTransform.rotation = clampedRotation;
        }
    }

    // Helper method to clamp the rotation
    private Quaternion ClampRotation(Quaternion currentRotation, Quaternion targetRotation, float maxAngle)
    {
        // Get the angle between the current and target rotations
        float angle = Quaternion.Angle(currentRotation, targetRotation);

        // If the angle exceeds the max angle, return the current rotation
        if (angle > maxAngle)
        {
            return currentRotation;
        }

        return targetRotation;
    }
}
