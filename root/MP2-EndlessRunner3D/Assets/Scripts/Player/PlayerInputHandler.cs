
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] InputActionMap map;
    public InputActionMap Map { get => map; set => map = value; }

    public UnityEngine.InputSystem.TouchPhase currenttouchPhase;
    public bool IsTouching 
    { 
        get => GetTouchingState(); 
    }

    internal bool GetTouchingState()
    {
        return false; // for now
    }
}
