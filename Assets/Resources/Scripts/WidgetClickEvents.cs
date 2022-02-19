using UnityEngine;

public class WidgetClickEvents : MonoBehaviour
{
    public void UpArrowPressed()
    {
        ScrollRectSnap snapper = GetComponentInChildren<ScrollRectSnap>();
        snapper.DraggedOnLeft();
    }

    public void DownArrowPressed()
    {
        ScrollRectSnap snapper = GetComponentInChildren<ScrollRectSnap>();
        snapper.DraggedOnRight();

    }
}
