using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{

    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.75f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    
    void Start()
    {
        
    }

   
    private void Update()
    {
        // Get the number of overlapping Colliders from the Players Interaction Point
        _numFound = Physics.OverlapSphereNonAlloc( _interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);


        // If we find a GameObject that has a Layer of Interactable
        if (_numFound > 0)
        {
            // Get the first of them
            _interactable = _colliders[0].GetComponent<IInteractable>();

            // Interact if not null and pass the player as argument
            if (_interactable != null)
            {
                // Set up and display the Interaction box above our player
                if (!_interactionPromptUI.isDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    if (_interactable.Interact(this))
                    {
                        // Refresh the prompt after interaction
                        _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
                    }
                }
            }
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.isDisplayed) _interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }


}
