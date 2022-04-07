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

    GameObject purchasePopUpGO;
    GameObject showroomGO;

    private int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        purchasePopUpGO = GameObject.Find("Purchase Pop-up");
        showroomGO = GameObject.Find("Showroom");

        overlay.alpha = 0;
        overlay.blocksRaycasts = false;

        purchasePopUp.alpha = 0;
        purchasePopUp.interactable = false;
        purchasePopUp.blocksRaycasts = false;
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

                default:
                    loadingManager.GetComponent<LoadingManager>().goBackToCarDealerManufacturer(context);
                    break;
            }
        }
    }
}
