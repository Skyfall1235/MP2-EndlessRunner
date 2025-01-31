using UnityEngine;

public class PowerUp_BubbleShield : MoveableObject, IInteractable
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

    //this could have been an override but i like abstract methods, it forces me to not forget them
    public void Interact(PlayerMovement movementController = null)
    {
        movementController.ToggleBubbleShield(true);
        Destroy(transform.parent.gameObject);
    }
}
