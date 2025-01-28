using UnityEngine;

public interface IInteractable
{
    public enum InteractableType
    {
        Powerup, Obststacle
    }

    public InteractableType interactType;
    /// <summary>
    /// Calls the interaction with the movement controller and the object hit to begin
    /// </summary>
    /// <param name="movementController"></param>
    public void Interact(PlayerMovement movementController = null);
}   
