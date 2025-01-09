using UnityEngine;

public interface IInteractable
{
    public enum InteractableType
    {
        Powerup, Obststacle
    }
    public void Interact();
}   
