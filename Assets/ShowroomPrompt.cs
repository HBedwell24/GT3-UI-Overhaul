using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShowroomPrompt : MonoBehaviour
{
    public GameObject loadingManager;

    [SerializeField]
    public CanvasGroup overlay;

    [SerializeField]
    public CanvasGroup purchasePopUp;

    [SerializeField]
    public CanvasGroup gameUI;

    GameObject purchasePopUpGO;
    GameObject showroomGO;

    private int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        purchasePopUpGO = GameObject.Find("Purchase Pop-up");
        showroomGO = GameObject.Find("Showroom");

        gameUI.alpha = 1;
        gameUI.interactable = true;
        gameUI.blocksRaycasts = true;

        overlay.alpha = 0;
        overlay.blocksRaycasts = false;

        purchasePopUp.alpha = 0;
        purchasePopUp.interactable = false;
        purchasePopUp.blocksRaycasts = false;
    }

    public void GalleryClicked()
    {
        counter = counter + 2;
        AudioManager.instance.PlaySoundEffect("Submenu Enter");
        StartCoroutine(FadeUI(true));
    }

    IEnumerator FadeUI(bool toTransparent)
    {
        if (toTransparent)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime * 2)
            {
                // set color with i as alpha
                gameUI.alpha = i;
                gameUI.interactable = false;
                gameUI.blocksRaycasts = false;
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime * 2)
            {
                // set color with i as alpha
                gameUI.alpha = i;
                gameUI.interactable = true;
                gameUI.blocksRaycasts = true;
                yield return null;
            }
        }
    }

    public void PurchaseCar()
    {
        counter++;
        AudioManager.instance.PlaySoundEffect("Submenu Enter");
        showroomGO.GetComponent<CursorBehavior>().enabled = false;
        purchasePopUpGO.GetComponent<CursorBehavior>().enabled = true;

        overlay.alpha = 1;
        overlay.blocksRaycasts = true;

        purchasePopUp.alpha = 1;
        purchasePopUp.interactable = true;
        purchasePopUp.blocksRaycasts = true;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("Yes"));
    }

    public void NoClicked()
    {
        AudioManager.instance.PlaySoundEffect("Submenu Exit");
        purchasePopUpGO.GetComponent<CursorBehavior>().enabled = false;
        showroomGO.GetComponent<CursorBehavior>().enabled = true;

        overlay.alpha = 0;
        overlay.blocksRaycasts = false;

        purchasePopUp.alpha = 0;
        purchasePopUp.interactable = false;
        purchasePopUp.blocksRaycasts = false;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("Enter"));
    }

    public void PromptExit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (counter)
            {
                case 2:
                    counter--;
                    AudioManager.instance.PlaySoundEffect("Submenu Exit");
                    purchasePopUpGO.GetComponent<CursorBehavior>().enabled = false;
                    showroomGO.GetComponent<CursorBehavior>().enabled = true;

                    overlay.alpha = 0;
                    overlay.blocksRaycasts = false;

                    purchasePopUp.alpha = 0;
                    purchasePopUp.interactable = false;
                    purchasePopUp.blocksRaycasts = false;

                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Enter"));
                    break;

                case 3:
                    counter = counter - 2;
                    AudioManager.instance.PlaySoundEffect("Submenu Exit");
                    StartCoroutine(FadeUI(false));
                    break;

                default:
                    loadingManager.GetComponent<LoadingManager>().goBackToCarDealerManufacturer(context);
                    break;
            }
        }
    }
}
