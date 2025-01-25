using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent OnTap;
    public bool DEBUGJUMP = true;

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && DEBUGJUMP)
        {
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
