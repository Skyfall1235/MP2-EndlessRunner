using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent OnTap;
    [SerializeField] InputAction Tap;
    //[SerializeField] private bool DEBUGJUMP = true;  NO LONGER NEEDED

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
        OnTap.Invoke();
    }
}
