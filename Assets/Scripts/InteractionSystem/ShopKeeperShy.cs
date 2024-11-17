using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperShy : MonoBehaviour, IInteractable
{
    [SerializeField] private string _promptTask = "Help! I need to find my pumpkin! I think i dropped it near your house! Press [E] to give item";
    [SerializeField] private string _promptTaskCompleted = "Thanks for your help!";
    private bool completedTask = false;

    public string InteractionPrompt
    {
        get
        { 
            // Check if the interactor (player) has completed the task
            var interactor = FindObjectOfType<Interactor>();
            var inventory = interactor?.GetComponent<Inventory>();

            if (inventory != null && inventory.hasPumpkin)
            {
                return _promptTaskCompleted;
            }
            else
            {
                return _promptTask;
            }
        }
    }

    public bool Interact(Interactor interactor)
    {
        // If the door is opened, dont execute
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        if (inventory.hasPumpkin)
        {
            // Open the door
            completedTask = true;
            Debug.Log("Gave the pumpkin");
            return true;
        }
        else
        {
            // Don't have the pumkin
            Debug.Log("No pumpkin in inventory");
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
