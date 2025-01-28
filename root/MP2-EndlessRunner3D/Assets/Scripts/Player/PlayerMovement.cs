using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class PlayerMovement : MoveableObject
{
    [SerializeField] private float jumpForce = 5f;
    public bool ReverseGravity;
    public bool TimeSlow;
    [SerializeField] private float PowerUpTime = 2f;
    [SerializeField] private float TimeSlowScale = 0.7f;

    void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
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
        objectRigidbody.MoveObject(UpDirection, jumpForce);
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