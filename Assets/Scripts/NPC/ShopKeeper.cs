
using UnityEngine;

public class ShopKeeper : NPCBase
{
    private Animator _animator;

    public override string InteractionPrompt
    {
        get
        {
            return completedTask ? "ShopKeeper: \"Thank you, friend!\"" : "ShopKeeper: \"Can you find my pumpkin? I lost it...\"\nPress [E] to give pumpkin";
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
            _animator.SetBool("FoundPumpkin", true);
            Debug.Log("Gave the pumpkin");
            return true;
        }
        else
        {
            Debug.Log("No pumpkin in inventory");
            return false;
        }
    }

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("FoundPumpkin", false);
    }
}
