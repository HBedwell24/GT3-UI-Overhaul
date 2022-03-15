using UnityEngine;
using UnityEngine.InputSystem;

public class WidgetClickEvents : MonoBehaviour
{
    public void R1Pressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ScrollRectSnap snapper = GetComponentInChildren<ScrollRectSnap>();
            snapper.DraggedOnLeft();
        }
    }

    public void L1Pressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ScrollRectSnap snapper = GetComponentInChildren<ScrollRectSnap>();
            snapper.DraggedOnRight();
        }
    }
}
