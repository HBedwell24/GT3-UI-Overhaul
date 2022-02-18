using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject previouslySelected;
   
    void Update()
    {
        void ScrollWithSelection(RectTransform _scrollRect, RectTransform _content)
        {
            GameObject selected = eventSystem.currentSelectedGameObject;
            if (selected == null || selected == previouslySelected) return;
            if (selected.transform.parent != _content.transform) return;
            RectTransform selectedRectTransform = selected.GetComponent<RectTransform>();


            float scrollViewMinY = _content.anchoredPosition.y;
            float scrollViewMaxY = _content.anchoredPosition.y + _scrollRect.rect.height;


            float selectedPositionY = Mathf.Abs(selectedRectTransform.anchoredPosition.y) + (selectedRectTransform.rect.height / 2);

            // If selection below scroll view
            if (selectedPositionY > scrollViewMaxY)
            {
                float newY = selectedPositionY - _scrollRect.rect.height;
                _content.anchoredPosition = new Vector2(_content.anchoredPosition.x, newY);
            }


            // If selection above scroll view
            else if (Mathf.Abs(selectedRectTransform.anchoredPosition.y) < scrollViewMinY)
            {
                _content.anchoredPosition =
                    new Vector2(_content.anchoredPosition.x, Mathf.Abs(selectedRectTransform.anchoredPosition.y)
                    - (selectedRectTransform.rect.height / 2));
            }
        }
    }
}
