using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // in this function we check for near colliders so the player can interact with
    void Update()
    {
        // call only on key 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            // interaction range
            float interactRange = 2f;


            // collider array of near colliders
            Collider[] nearColliders = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in nearColliders)
            {
                Debug.Log(collider);
            }
        }
              
    }
}
