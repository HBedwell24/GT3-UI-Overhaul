using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SliderMenuAnim : MonoBehaviour
{
    public GameObject PanelMenu;

    [SerializeField]
    private CanvasGroup sideBar;

    [SerializeField]
    private CanvasGroup seperator;

    [SerializeField]
    private CanvasGroup overlay;

    public void Awake()
    {
        sideBar.alpha = 0;
        sideBar.interactable = false;
        sideBar.blocksRaycasts = false;

        seperator.alpha = 0;
        seperator.blocksRaycasts = false;

        overlay.alpha = 0;
        overlay.blocksRaycasts = false;
    }

    public void ShowHideMenu(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (PanelMenu != null)
            {
                Animator animator = PanelMenu.GetComponent<Animator>();
                if (animator != null)
                {
                    bool isOpen = animator.GetBool("show");
                    animator.SetBool("show", !isOpen);

                    // fade from opaque to transparent
                    if (isOpen)
                    {
                        AudioManager.instance.PlaySoundEffect("Submenu Exit");
                        DisableAllButtons();
                    }
                    // fade from transparent to opaque
                    else
                    {
                        AudioManager.instance.PlaySoundEffect("Submenu Enter");
                        EnableAllButtons();

                    }
                    StartCoroutine(FadeImage(isOpen));
                }
            }
        }
    }

    public void DisableAllButtons()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        foreach (GameObject g in buttons)
        {
            //g.GetComponent<Button>().interactable = false;
        }
    }

    public void EnableAllButtons()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        foreach (GameObject g in buttons)
        {
            //g.GetComponent<Button>().interactable = true;
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
                seperator.blocksRaycasts = false;

                sideBar.interactable = false;
                sideBar.blocksRaycasts = false;

                overlay.alpha = i;
                overlay.blocksRaycasts = false;
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
                seperator.blocksRaycasts = true;

                sideBar.interactable = true;
                sideBar.blocksRaycasts = true;

                overlay.alpha = i;
                overlay.blocksRaycasts = true;
                yield return null;
            }
        }
    }
}
