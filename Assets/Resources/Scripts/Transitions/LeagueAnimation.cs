using UnityEngine;
using UnityEngine.EventSystems;

public class LeagueAnimation : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        ShowHideLeague();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ShowHideLeague();
    }

    public void ShowHideLeague()
    {
        if (gameObject != null)
        {
            Animator animator = gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }
}
