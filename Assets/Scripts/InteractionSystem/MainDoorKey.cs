using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorKey : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;


    [SerializeField] public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();

        if (inventory == null) return false;

        // Set the hasMainDoorKey boolean to True -> Player got the key
        inventory.hasMainDoorKey = true;

        // Hide the Key
        gameObject.SetActive(false);

        Debug.Log("Got the door key");

        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
