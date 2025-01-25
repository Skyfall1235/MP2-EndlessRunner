using System.Collections;
using UnityEngine;

public class PlayerMovement : MoveableObject
{
    //read movment every frame
    //aply force every frame
    // have th ability to toggle on and off

    //for now
    public float jumpForce = 5f;
    private Rigidbody rb;
    public bool ReverseGravity;
    public bool TimeSlow;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void ForceJump()
    {
        //this is evoked via event so it just needs to execute
        Vector3 UpDirection = Vector3.up;
        if(ReverseGravity)
        {
            UpDirection = Vector3.down;
        }
        rb.linearVelocity = UpDirection * jumpForce;
    }
}