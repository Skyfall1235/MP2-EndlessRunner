using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp_GravitySwitch : MoveableObject, IInteractable
{

    public IInteractable.InteractableType InteractType
    {
        get
        {
            return interactionType;
        }
    }

    private void Update()
    {
        if (transform.position.x <= -60)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    [SerializeField] private IInteractable.InteractableType interactionType;
    //never got added :(
    //couldnt find a good model for it and so this was scrapped for time at the last minute
    public void Interact(PlayerMovement movementController = null)
    {
        movementController.ChangeGravity();
    }
}
