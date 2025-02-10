using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollisionHandler : MonoBehaviour
{
    /// <summary>
    /// /will fix to make this publicly accessible only later
    /// </summary>
    public PlayerMovement m_movement;
    //this is gonna be a lot of collision stuff, like geez
    //we made an interface, check for that, then refer to type.

    private void Awake()
    {
        m_movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if the collision is with an interactable object
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        //attempt to interact with the object with null prop
        interactable?.Interact(m_movement);
    }

}
