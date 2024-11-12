using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] public string InteractionPrompt => _prompt;
    //public string InteractionPrompt { get => _prompt; }

    public bool Interact(Interactor interactor)
    {
        var gameObjectName = this.name;
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;
        
        if (inventory.hasMainDoorKey)
        {
            Debug.Log("Opening door " + gameObjectName);
            return true;
        }
        else
        {
            Debug.Log("No key found");
            return false;
        }

        
    }

    void Start()
    {
        
    }

 
    void Update()
    {
        
    }


}
