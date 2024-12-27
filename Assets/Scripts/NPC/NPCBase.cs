using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBase : MonoBehaviour, IInteractable
{
    
    [SerializeField] protected string promptTask = "I have a task for you!";
    [SerializeField] protected string promptTaskCompleted = "Thanks for completing my task!";
    [SerializeField] protected float interactionRange = 3f;

    protected bool completedTask = false;

    public abstract string InteractionPrompt { get; }

    public abstract bool Interact(Interactor interactor);    
}
