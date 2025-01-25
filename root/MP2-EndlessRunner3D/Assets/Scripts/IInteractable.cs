using UnityEngine;

public interface IInteractable
{
    public enum InteractableType
    {
        Powerup, Obststacle
    }
    /// <summary>
    /// Calls the interaction with the movemnet controller and the object hit to begin
    /// </summary>
    /// <param name="movementController"></param>
    public void Interact(PlayerMovement movementController = null);
}   
