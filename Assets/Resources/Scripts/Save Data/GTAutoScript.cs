using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GTAutoScript : MonoBehaviour
{
    public GameObject loadingManager;

    [SerializeField]
    public CanvasGroup servicingTitle;

    [SerializeField]
    public CanvasGroup carWashTitle;

    [SerializeField]
    public CanvasGroup oilChangeTitle;

    [SerializeField]
    public CanvasGroup wheelShopTitle;

    [SerializeField]
    public CanvasGroup menuGroup;

    [SerializeField]
    public CanvasGroup washCarButton;

    [SerializeField]
    public CanvasGroup changeOilButton;

    [SerializeField]
    public CanvasGroup oilMeter;

    [SerializeField]
    public CanvasGroup brandSelectionMenu;

    [SerializeField]
    public CanvasGroup wheelSelectionMenu;

    [SerializeField]
    public CanvasGroup staticCursor;

    private string currentScreen;
    private string gameObjectName;

    GameObject menuGroupGO;
    GameObject wheelGroup;
    GameObject brandGroup;

    public void Start()
    {
        menuGroupGO = GameObject.Find("Menu Group");
        wheelGroup = GameObject.Find("Wheel Group");
        brandGroup = GameObject.Find("Brand Group");

        wheelGroup.GetComponent<CursorBehavior>().enabled = false;
        brandGroup.GetComponent<CursorBehavior>().enabled = false;

        currentScreen = "menuGroup";

        carWashTitle.alpha = 0;
        oilChangeTitle.alpha = 0;
        wheelShopTitle.alpha = 0;
        staticCursor.alpha = 0;

        brandSelectionMenu.alpha = 0;
        brandSelectionMenu.interactable = false;
        brandSelectionMenu.blocksRaycasts = false;

        wheelSelectionMenu.alpha = 0;
        wheelSelectionMenu.interactable = false;
        wheelSelectionMenu.blocksRaycasts = false;

        washCarButton.alpha = 0;
        washCarButton.interactable = false;
        washCarButton.blocksRaycasts = false;

        changeOilButton.alpha = 0;
        changeOilButton.interactable = false;
        changeOilButton.blocksRaycasts = false;

        oilMeter.alpha = 0;
        
        menuGroup.alpha = 1;
        menuGroup.interactable = true;
        menuGroup.blocksRaycasts = true;

        servicingTitle.alpha = 1;
    }

    public void CarWashClicked()
    {
        menuGroupGO.GetComponent<CursorBehavior>().enabled = false;

        currentScreen = "carWash";

        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        servicingTitle.alpha = 0;
        carWashTitle.alpha = 1;
        staticCursor.alpha = 1;

        menuGroup.alpha = 0;
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;

        washCarButton.alpha = 1;
        washCarButton.interactable = true;
        washCarButton.blocksRaycasts = true;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("Wash Car"));
    }

    public void OilChangeClicked()
    {
        menuGroupGO.GetComponent<CursorBehavior>().enabled = false;

        currentScreen = "oilChange";

        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        servicingTitle.alpha = 0;
        oilChangeTitle.alpha = 1;
        staticCursor.alpha = 1;

        menuGroup.alpha = 0;
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;

        changeOilButton.alpha = 1;
        changeOilButton.interactable = true;
        changeOilButton.blocksRaycasts = true;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("Oil Change Button"));
    }

    public void WheelShopClicked()
    {
        menuGroupGO.GetComponent<CursorBehavior>().enabled = false;
        brandGroup.GetComponent<CursorBehavior>().enabled = true;

        currentScreen = "brandSelection";

        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        servicingTitle.alpha = 0;
        wheelShopTitle.alpha = 1;

        menuGroup.alpha = 0;
        menuGroup.interactable = false;
        menuGroup.blocksRaycasts = false;

        brandSelectionMenu.alpha = 1;
        brandSelectionMenu.interactable = true;
        brandSelectionMenu.blocksRaycasts = true;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("Enkei"));
    }

    public void BrandClicked()
    {
        gameObjectName = EventSystem.current.currentSelectedGameObject.name;
        brandGroup.GetComponent<CursorBehavior>().enabled = false;
        wheelGroup.GetComponent<CursorBehavior>().enabled = true;

        currentScreen = "wheelSelection";

        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        brandSelectionMenu.alpha = 0;
        brandSelectionMenu.interactable = false;
        brandSelectionMenu.blocksRaycasts = false;

        wheelSelectionMenu.alpha = 1;
        wheelSelectionMenu.interactable = true;
        wheelSelectionMenu.blocksRaycasts = true;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("CE28"));
    }

    public void PromptExit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (currentScreen)
            {
                
                case "carWash":
                    menuGroupGO.GetComponent<CursorBehavior>().enabled = true;

                    AudioManager.instance.PlaySoundEffect("Submenu Exit");

                    carWashTitle.alpha = 0;
                    staticCursor.alpha = 0;

                    washCarButton.alpha = 0;
                    washCarButton.interactable = false;
                    washCarButton.blocksRaycasts = false;

                    menuGroup.alpha = 1;
                    menuGroup.interactable = true;
                    menuGroup.blocksRaycasts = true;

                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Car Wash"));

                    servicingTitle.alpha = 1;
                    currentScreen = "menuGroup";
                    break;

                case "oilChange":
                    menuGroupGO.GetComponent<CursorBehavior>().enabled = true;

                    AudioManager.instance.PlaySoundEffect("Submenu Exit");

                    oilChangeTitle.alpha = 0;
                    staticCursor.alpha = 0;

                    changeOilButton.alpha = 0;
                    changeOilButton.interactable = false;
                    changeOilButton.blocksRaycasts = false;

                    menuGroup.alpha = 1;
                    menuGroup.interactable = true;
                    menuGroup.blocksRaycasts = true;

                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Oil Change"));

                    servicingTitle.alpha = 1;
                    currentScreen = "menuGroup";
                    break;

                case "brandSelection":
                    brandGroup.GetComponent<CursorBehavior>().enabled = false;
                    menuGroupGO.GetComponent<CursorBehavior>().enabled = true;

                    AudioManager.instance.PlaySoundEffect("Submenu Exit");

                    wheelShopTitle.alpha = 0;

                    brandSelectionMenu.alpha = 0;
                    brandSelectionMenu.interactable = false;
                    brandSelectionMenu.blocksRaycasts = false;

                    menuGroup.alpha = 1;
                    menuGroup.interactable = true;
                    menuGroup.blocksRaycasts = true;

                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Wheel Shop"));

                    servicingTitle.alpha = 1;
                    currentScreen = "menuGroup";
                    break;

                case "wheelSelection":
                    brandGroup.GetComponent<CursorBehavior>().enabled = true;
                    wheelGroup.GetComponent<CursorBehavior>().enabled = false;

                    AudioManager.instance.PlaySoundEffect("Submenu Exit");

                    wheelSelectionMenu.alpha = 0;
                    wheelSelectionMenu.interactable = false;
                    wheelSelectionMenu.blocksRaycasts = false;

                    brandSelectionMenu.alpha = 1;
                    brandSelectionMenu.interactable = true;
                    brandSelectionMenu.blocksRaycasts = true;

                    EventSystem.current.SetSelectedGameObject(GameObject.Find(gameObjectName));
                    currentScreen = "brandSelection";
                    break;

                default:
                    loadingManager.GetComponent<LoadingManager>().goBackToSimulationMode(context);
                    break;
            }
        }
    }
}
