using System.Collections;
using UnityEngine;

public class CarConfigScript : MonoBehaviour
{
    public AudioSource promptConfirm;
    public AudioSource goBack;

    [SerializeField]
    private CanvasGroup colorSelectionPrompt;

    [SerializeField]
    private CanvasGroup transmissionPrompt;

    [SerializeField]
    private CanvasGroup raceDifficultySelection;

    [SerializeField]
    private CanvasGroup panel;

    [SerializeField]
    private CanvasGroup racePrompt;

    [SerializeField]
    private CanvasGroup carInformation;

    [SerializeField]
    private CanvasGroup controls;

    public void Awake()
    {
        colorSelectionPrompt.alpha = 1;

        carInformation.alpha = 1;

        controls.alpha = 1;
        controls.interactable = true;

        transmissionPrompt.alpha = 0;
        transmissionPrompt.interactable = false;

        raceDifficultySelection.alpha = 0;
        raceDifficultySelection.interactable = false;

        panel.alpha = 0;
        panel.interactable = false;

        racePrompt.alpha = 0;
        racePrompt.interactable = false;
    }

    IEnumerator PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
        yield return null;       
    }

    public void SelectColor()
    {
        StartCoroutine(PlaySound(promptConfirm));

        colorSelectionPrompt.alpha = 0;
        colorSelectionPrompt.interactable = false;

        transmissionPrompt.alpha = 1;
        transmissionPrompt.interactable = true;
    }

    public void SelectTransmissionType()
    {
        StartCoroutine(PlaySound(promptConfirm));

        transmissionPrompt.alpha = 0;
        transmissionPrompt.interactable = false;

        raceDifficultySelection.alpha = 1;
        raceDifficultySelection.interactable = true;
    }

    public void SelectRaceDifficulty()
    {
        StartCoroutine(PlaySound(promptConfirm));

        raceDifficultySelection.alpha = 0;
        raceDifficultySelection.interactable = false;

        panel.alpha = 1;

        racePrompt.alpha = 1;
        racePrompt.interactable = true;
    }
}
