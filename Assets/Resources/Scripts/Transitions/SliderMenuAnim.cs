using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SliderMenuAnim : MonoBehaviour
{
    public GameObject PanelMenu;

    [SerializeField]
    private CanvasGroup sideBar;

    [SerializeField]
    private CanvasGroup seperator;

    [SerializeField]
    private CanvasGroup overlay;

    private GameObject lastSelectedGameObject;
    private GameObject currentSelectedGameObject_Recent;

    [SerializeField]
    private Material material;

    bool isOpen;

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

    void Update()
    {
        if (lastSelectedGameObject == null)
        {
            lastSelectedGameObject = EventSystem.current.firstSelectedGameObject;
        }
        GetLastGameObjectSelected();
    }

    private void GetLastGameObjectSelected()
    {
        if (EventSystem.current.currentSelectedGameObject != currentSelectedGameObject_Recent)
        {
            if (!EventSystem.current.currentSelectedGameObject.name.Contains("Save Game") && !EventSystem.current.currentSelectedGameObject.name.Contains("Load Game") && !EventSystem.current.currentSelectedGameObject.name.Contains("Options") && !isOpen)
            {
                lastSelectedGameObject = currentSelectedGameObject_Recent;
            }
            
            currentSelectedGameObject_Recent = EventSystem.current.currentSelectedGameObject;
        }
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
                    isOpen = animator.GetBool("show");
                    animator.SetBool("show", !isOpen);

                    // fade from opaque to transparent
                    if (isOpen)
                    {
                        AudioManager.instance.PlaySoundEffect("Submenu Exit");
                        sideBar.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
                        sideBar.GetComponent<Image>().material = null;
                        
                        EventSystem.current.SetSelectedGameObject(lastSelectedGameObject);
                            
                    }
                    // fade from transparent to opaque
                    else
                    {
                        AudioManager.instance.PlaySoundEffect("Submenu Enter");
                        sideBar.GetComponent<Image>().color = new Color(255, 255, 255, 1f); ;
                        sideBar.GetComponent<Image>().material = material;
                        EventSystem.current.SetSelectedGameObject(GameObject.Find("Save Game"));
                    }
                    StartCoroutine(FadeImage(isOpen));
                }
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
