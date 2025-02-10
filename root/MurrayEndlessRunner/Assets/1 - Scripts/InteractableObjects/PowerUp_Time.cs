using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp_Time : MoveableObject, IInteractable
{
    public IInteractable.InteractableType InteractType
    {
        get
        {
            return interactionType;
        }
    }

    [SerializeField] private IInteractable.InteractableType interactionType;

    public void Interact(PlayerMovement movementController = null)
    {

    }
}
