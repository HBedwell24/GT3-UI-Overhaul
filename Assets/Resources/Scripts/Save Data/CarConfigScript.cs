using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CarConfigScript : MonoBehaviour
{
    public GameObject loadingManager;

    [SerializeField]
    public CanvasGroup colorSelectionPrompt;

    [SerializeField]
    public CanvasGroup transmissionPrompt;

    [SerializeField]
    public CanvasGroup raceDifficultySelection;

    [SerializeField]
    public CanvasGroup panel;

    [SerializeField]
    public CanvasGroup racePrompt;

    [SerializeField]
    public CanvasGroup carInformation;

    [SerializeField]
    public CanvasGroup controls;

    private int counter = 1;
    private string color;
    private string transmission;
    private string difficulty;
   
    GameObject colorSelectionGO;
    GameObject transmissionGO;
    GameObject raceDifficultyGO;
    GameObject racePromptGO;

    public void Start()
    {
        colorSelectionGO = GameObject.Find("Color Selection Prompt");
        transmissionGO = GameObject.Find("Transmission Prompt");
        raceDifficultyGO = GameObject.Find("Race Difficulty Selection");
        racePromptGO = GameObject.Find("Race Prompt");

        transmissionGO.GetComponent<CursorBehavior>().enabled = false;
        raceDifficultyGO.GetComponent<CursorBehavior>().enabled = false;
        racePromptGO.GetComponent<CursorBehavior>().enabled = false;

        colorSelectionPrompt.alpha = 1;
        colorSelectionPrompt.interactable = true;
        colorSelectionPrompt.blocksRaycasts = true;

        carInformation.alpha = 1;

        controls.alpha = 1;
        controls.interactable = true;
        controls.blocksRaycasts = true;

        transmissionPrompt.alpha = 0;
        transmissionPrompt.interactable = false;
        transmissionPrompt.blocksRaycasts = false;

        raceDifficultySelection.alpha = 0;
        raceDifficultySelection.interactable = false;
        raceDifficultySelection.blocksRaycasts = false;

        panel.alpha = 0;

        racePrompt.alpha = 0;
        racePrompt.interactable = false;
        racePrompt.blocksRaycasts = false;
    }

    public void SelectColor()
    {
        color = EventSystem.current.currentSelectedGameObject.name;

        colorSelectionGO.GetComponent<CursorBehavior>().enabled = false;
        transmissionGO.GetComponent<CursorBehavior>().enabled = true;

        // increment to 2
        counter++;
        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        colorSelectionPrompt.alpha = 0;
        colorSelectionPrompt.interactable = false;
        colorSelectionPrompt.blocksRaycasts = false;

        transmissionPrompt.alpha = 1;
        transmissionPrompt.interactable = true;
        transmissionPrompt.blocksRaycasts = true;

        if (transmission != null)
        {
            EventSystem.current.SetSelectedGameObject(GameObject.Find(transmission));
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(GameObject.Find("Automatic"));
        }
    }

    public void SelectTransmissionType()
    {
        transmission = EventSystem.current.currentSelectedGameObject.name;

        transmissionGO.GetComponent<CursorBehavior>().enabled = false;
        raceDifficultyGO.GetComponent<CursorBehavior>().enabled = true;

        // increment to 3
        counter++;
        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        transmissionPrompt.alpha = 0;
        transmissionPrompt.interactable = false;
        transmissionPrompt.blocksRaycasts = false;

        raceDifficultySelection.alpha = 1;
        raceDifficultySelection.interactable = true;
        raceDifficultySelection.blocksRaycasts = true;

        if (difficulty != null)
        {
            EventSystem.current.SetSelectedGameObject(GameObject.Find(difficulty));
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(GameObject.Find("Beginner"));
        }
    }

    public void SelectRaceDifficulty()
    {
        difficulty = EventSystem.current.currentSelectedGameObject.name;

        raceDifficultyGO.GetComponent<CursorBehavior>().enabled = false;
        racePrompt.GetComponent<CursorBehavior>().enabled = true;

        // increment to 4
        counter++;
        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        raceDifficultySelection.alpha = 0;
        raceDifficultySelection.interactable = false;
        raceDifficultySelection.blocksRaycasts = false;

        controls.alpha = 0;
        controls.interactable = false;
        controls.blocksRaycasts = false;

        carInformation.alpha = 0;

        panel.alpha = 1;

        racePrompt.alpha = 1;
        racePrompt.interactable = true;
        racePrompt.blocksRaycasts = true;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("Cancel"));
    }

    public void Cancel()
    {
        raceDifficultyGO.GetComponent<CursorBehavior>().enabled = true;
        racePrompt.GetComponent<CursorBehavior>().enabled = false;

        counter--;
        AudioManager.instance.PlaySoundEffect("Submenu Exit");

        racePrompt.alpha = 0;
        racePrompt.interactable = false;
        racePrompt.blocksRaycasts = false;

        panel.alpha = 0;

        controls.alpha = 1;
        controls.interactable = true;
        controls.blocksRaycasts = true;

        carInformation.alpha = 1;

        raceDifficultySelection.alpha = 1;
        raceDifficultySelection.interactable = true;
        raceDifficultySelection.blocksRaycasts = true;

        EventSystem.current.SetSelectedGameObject(GameObject.Find(difficulty));
    }

    public void PromptExit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (counter)
            {
                case 2:
                    colorSelectionGO.GetComponent<CursorBehavior>().enabled = true;
                    transmissionGO.GetComponent<CursorBehavior>().enabled = false;

                    counter--;
                    AudioManager.instance.PlaySoundEffect("Submenu Exit");

                    transmissionPrompt.alpha = 0;
                    transmissionPrompt.interactable = false;
                    transmissionPrompt.blocksRaycasts = false;

                    colorSelectionPrompt.alpha = 1;
                    colorSelectionPrompt.interactable = true;
                    colorSelectionPrompt.blocksRaycasts = true;

                    EventSystem.current.SetSelectedGameObject(GameObject.Find(color));
                    break;

                case 3:
                    transmissionGO.GetComponent<CursorBehavior>().enabled = true;
                    raceDifficultyGO.GetComponent<CursorBehavior>().enabled = false;

                    counter--;
                    AudioManager.instance.PlaySoundEffect("Submenu Exit");

                    raceDifficultySelection.alpha = 0;
                    raceDifficultySelection.interactable = false;
                    raceDifficultySelection.blocksRaycasts = false;

                    transmissionPrompt.alpha = 1;
                    transmissionPrompt.interactable = true;
                    transmissionPrompt.blocksRaycasts = true;

                    EventSystem.current.SetSelectedGameObject(GameObject.Find(transmission));

                    break;

                case 4:
                    raceDifficultyGO.GetComponent<CursorBehavior>().enabled = true;
                    racePrompt.GetComponent<CursorBehavior>().enabled = false;

                    counter--;
                    AudioManager.instance.PlaySoundEffect("Submenu Exit");

                    racePrompt.alpha = 0;
                    racePrompt.interactable = false;
                    racePrompt.blocksRaycasts = false;

                    panel.alpha = 0;

                    controls.alpha = 1;
                    controls.interactable = true;
                    controls.blocksRaycasts = true;

                    carInformation.alpha = 1;

                    raceDifficultySelection.alpha = 1;
                    raceDifficultySelection.interactable = true;
                    raceDifficultySelection.blocksRaycasts = true;

                    EventSystem.current.SetSelectedGameObject(GameObject.Find(difficulty));

                    break;

                default:
                    loadingManager.GetComponent<LoadingManager>().goBackToCourtesyCars(context);
                    break;
            }
        }
    }
}
