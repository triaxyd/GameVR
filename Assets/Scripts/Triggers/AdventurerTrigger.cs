using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdventurerTrigger : MonoBehaviour
{
    [SerializeField]
    UnityEvent onTriggerEnter;

    [SerializeField]
    private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Adventurer")
        {
            Debug.Log("Adventurer entered the trigger.");
            onTriggerEnter.Invoke();

            // Get Adventurer component
            Adventurer adventurer = other.GetComponent<Adventurer>();
            if (adventurer != null)
            {
                // Disable follow player enable patrol and play wave animation
                adventurer.GetComponent<MoveNPC>().enabled = false;
                adventurer.GetComponent<Patrol>().enabled = true;
                adventurer.SetFollowPlayer(false);
                adventurer.SetFollowFriends(true);
            }
        }
    }
}
