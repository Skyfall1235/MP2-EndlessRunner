using UnityEngine;

public class BaseInteractable : MonoBehaviour, IInteractable
{
    public IInteractable.InteractableType InteractType
    {
        get
        {
            return interactionType;
        }
    }

    [SerializeField] private IInteractable.InteractableType interactionType;
    public virtual void Interact(PlayerMovement m)
    {
        throw new System.NotImplementedException();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        throw new System.NotImplementedException();
        //the plan is to detect interactions here and who with to ensure proper interactions between objects occur
    }
}
