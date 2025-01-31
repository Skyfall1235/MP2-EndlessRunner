using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class PlayerMovement : MoveableObject
{
    [SerializeField] private float jumpForce = 5f;
    public bool ReverseGravity;
    public bool TimeSlow;
    public bool IsUsingShield = false;
    [SerializeField] private float PowerUpTime = 2f;
    [SerializeField] private float TimeSlowScale = 0.7f;
    public GameSpawner spawner;
    public UnityEvent<bool> ToggleShield = new UnityEvent<bool>();

    void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(ReverseGravity)
        {
            objectRigidbody.AddForce(Vector3.up * 9.81f, ForceMode.Acceleration);
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
        MoveObject(UpDirection, jumpForce);
    }

    public void ChangeGravity()
    {
        StartCoroutine(ChangeGravitySequence());
    }

    public void SlowTime()
    {
        StartCoroutine(SlowTimeSequence());
    }

    /// <summary>
    /// Sets the active state of the shield to the boolean input
    /// </summary>
    /// <param name="val">the boolean input</param>
    public void ToggleBubbleShield(bool val)
    {
        IsUsingShield = val;
        ToggleShield.Invoke(val);
    }

    IEnumerator ChangeGravitySequence()
    {
        objectRigidbody.useGravity = false;
        ReverseGravity = true;
        yield return new WaitForSeconds(PowerUpTime);
        ReverseGravity = false;
        objectRigidbody.useGravity = true;
    }
    
    IEnumerator SlowTimeSequence()
    {
        Time.timeScale = TimeSlowScale;
        TimeSlow = true;
        yield return new WaitForSeconds(PowerUpTime);
        TimeSlow = false;
        Time.timeScale = 1f;
    }
}