using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent OnTap;
    [SerializeField] private bool DEBUGJUMP = true;

    private void Update()
    {
        //for debug purposes in the computer
        if(Input.GetKeyDown(KeyCode.Space) && DEBUGJUMP)
        {
            Debug.Log("Pressing Jump Button");
            OnTap.Invoke();
            return;
        }

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
