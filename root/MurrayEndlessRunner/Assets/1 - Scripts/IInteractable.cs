using UnityEngine;

public interface IInteractable
{
    public enum InteractableType
    {
        Powerup, Obststacle
    }

    public InteractableType InteractType { get; }
    /// <summary>
    /// Calls the interaction with the movement controller and the object hit to begin
    /// </summary>
    /// <param name="movementController"></param>
    public abstract void Interact(PlayerMovement movementController = null);
}   
