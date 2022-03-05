using UnityEngine;

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

    public void Start()
    {
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
        // increment to 2
        counter++;
        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        colorSelectionPrompt.alpha = 0;
        colorSelectionPrompt.interactable = false;
        colorSelectionPrompt.blocksRaycasts = false;

        transmissionPrompt.alpha = 1;
        transmissionPrompt.interactable = true;
        transmissionPrompt.blocksRaycasts = true;
    }

    public void SelectTransmissionType()
    {
        // increment to 3
        counter++;
        AudioManager.instance.PlaySoundEffect("Submenu Enter");

        transmissionPrompt.alpha = 0;
        transmissionPrompt.interactable = false;
        transmissionPrompt.blocksRaycasts = false;

        raceDifficultySelection.alpha = 1;
        raceDifficultySelection.interactable = true;
        raceDifficultySelection.blocksRaycasts = true;
    }

    public void SelectRaceDifficulty()
    {
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
    }

    public void PromptExit()
    {
        switch (counter)
        {
            case 2:
                counter--;
                AudioManager.instance.PlaySoundEffect("Submenu Exit");

                transmissionPrompt.alpha = 0;
                transmissionPrompt.interactable = false;
                transmissionPrompt.blocksRaycasts = false;

                colorSelectionPrompt.alpha = 1;
                colorSelectionPrompt.interactable = true;
                colorSelectionPrompt.blocksRaycasts = true;
                break;

            case 3:
                counter--;
                AudioManager.instance.PlaySoundEffect("Submenu Exit");

                raceDifficultySelection.alpha = 0;
                raceDifficultySelection.interactable = false;
                raceDifficultySelection.blocksRaycasts = false;

                transmissionPrompt.alpha = 1;
                transmissionPrompt.interactable = true;
                transmissionPrompt.blocksRaycasts = true;
                
                break;

            case 4:
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
                
                break;

            default:
                //loadingManager.GetComponent<LoadingManager>().LoadScene(InputAction.context, "Courtesy Cars,false");
                break;
        }
    }
}
