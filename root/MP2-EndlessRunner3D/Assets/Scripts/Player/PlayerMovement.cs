using System.Collections;
using Unity.VisualScripting;
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
    public float PowerUpTime = 2f;
    public float TimeSlowScale = 0.7f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(ReverseGravity)
        {
            rb.AddForce(Vector3.up * 9.81f, ForceMode.Acceleration);
        }
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
    public void ChangeGravity()
    {
        StartCoroutine(ChangeGravitySequence());
    }
    public void SlowTime()
    {
        StartCoroutine(SlowTimeSequence());
    }

    IEnumerator ChangeGravitySequence()
    {
        rb.useGravity = false;
        yield return new WaitForSeconds(PowerUpTime);
        rb.useGravity = true;
    }
    
    IEnumerator SlowTimeSequence()
    {
        Time.timeScale = TimeSlowScale;
        yield return new WaitForSeconds(PowerUpTime);
        Time.timeScale = 1f;
    }
}