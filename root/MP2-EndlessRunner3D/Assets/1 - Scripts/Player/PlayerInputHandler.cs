using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent OnTap;
    //[SerializeField] private bool DEBUGJUMP = true;  NO LONGER NEEDED

    private void Update()
    {
        if (Input.touchCount < 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnTap.Invoke();
                return;
            }
        } 
    }
}
