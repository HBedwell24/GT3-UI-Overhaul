using System.Collections;
using UnityEngine;

public class SliderMenuAnim : MonoBehaviour
{
    public GameObject PanelMenu;

    [SerializeField]
    private CanvasGroup sideBar;

    [SerializeField]
    private CanvasGroup seperator;

    public void Awake()
    {
        sideBar.alpha = 0;
        sideBar.interactable = false;

        seperator.alpha = 0;
    }

    public void ShowHideMenu()
    {
        if(PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);

                // fade from opaque to transparent
                if (isOpen)
                {
                    FindObjectOfType<AudioManager>().Play("Submenu Enter");
                }
                // fade from transparent to opaque
                else
                {
                    FindObjectOfType<AudioManager>().Play("Submenu Exit");
                }
                StartCoroutine(FadeImage(isOpen));
            }
        }
    }

    IEnumerator FadeImage(bool isOpen)
    {

        // fade from opaque to transparent
        if (isOpen)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime * 2)
            {
                // set color with i as alpha
                sideBar.alpha = i;
                seperator.alpha = i;

                sideBar.interactable = false;
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime * 2)
            {
                // set color with i as alpha
                sideBar.alpha = i;
                seperator.alpha = i;

                sideBar.interactable = true;
                yield return null;
            }
        }
    }
}
