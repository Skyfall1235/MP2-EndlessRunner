using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent OnTap;
    [SerializeField] InputAction Tap;

    //unity event based action mapping and event invoking
    private void OnEnable()
    {
        Tap.Enable();
    }
    private void OnDisable()
    {
        Tap.Disable();
    }
    private void Awake()
    {
        Tap.performed += TapCtx;
    }


    private void TapCtx(InputAction.CallbackContext context)
    {
        Debug.Log("tapping");
        OnTap.Invoke();
    }
}
