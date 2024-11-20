
using UnityEngine;

public class ShopKeeperShy : NPCBase
{
    public override string InteractionPrompt
    {
        get
        {
            return completedTask ? "Thanks for the pumpkin" : "Can you find my pumpkin? I think i lost it near the river...Press [E] to give item";
        }
    }

    public override bool Interact(Interactor interactor)
    {    
        var inventory = interactor.GetComponent<Inventory>();
        if (inventory == null) return false;

        if (!completedTask && inventory.hasPumpkin)
        {
            completedTask = true;
            inventory.hasPumpkin = false;
            Debug.Log("Gave the pumpkin");
            return true;
        }
        else
        {
            Debug.Log("No pumpkin in inventory");
            return false;
        }
        return true;
    }
}