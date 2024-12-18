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
    private GameObject target;

    protected bool completedTask = false;

    public abstract string InteractionPrompt { get; }

    public abstract bool Interact(Interactor interactor);

    void Start() 
    {
 
    }

    void Update()
    {
        // Check if the player is in range
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= interactionRange)
        {
            
        }
    }

    
}
