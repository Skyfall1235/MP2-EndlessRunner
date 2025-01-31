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

    public void Interact(PlayerMovement movementController = null)
    {
        movementController.ToggleBubbleShield(true);
    }
}
