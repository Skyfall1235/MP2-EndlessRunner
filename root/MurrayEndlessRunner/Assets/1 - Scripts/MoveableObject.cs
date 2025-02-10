using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveableObject : MonoBehaviour
{
    //insert the abilities to move through phyisics here. will do later.

    [SerializeField] protected Rigidbody objectRigidbody;
    public Rigidbody ObjectRigidbody { get => objectRigidbody; set => objectRigidbody = value; }

    //Basic Add force method to narrow behavior to a single call
    public void MoveObject(Vector3 Direction, float speed)
    {
        objectRigidbody.AddForce(speed * Time.deltaTime * Direction); 
    }

    //if the object needs to stop, call this
    public void HaltObjectMovement()
    {
        objectRigidbody.linearVelocity = Vector3.zero;
    }

    //for when i need to check grounded state
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}
