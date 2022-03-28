using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    [SerializeField]
    public CanvasGroup displayGroup;

    [SerializeField]
    public CanvasGroup audioGroup;

    void Start()
    {
        displayGroup.alpha = 0;
        displayGroup.interactable = false;
        displayGroup.blocksRaycasts = false;

        audioGroup.alpha = 0;
        audioGroup.interactable = false;
        audioGroup.blocksRaycasts = false;
    }

    public void DisplayClicked()
    {
        audioGroup.alpha = 0;
        audioGroup.interactable = false;
        audioGroup.blocksRaycasts = false;

        displayGroup.alpha = 1;
        displayGroup.interactable = true;
        displayGroup.blocksRaycasts = true;
    }

    public void AudioPlayed()
    {
        displayGroup.alpha = 0;
        displayGroup.interactable = false;
        displayGroup.blocksRaycasts = false;

        audioGroup.alpha = 1;
        audioGroup.interactable = true;
        audioGroup.blocksRaycasts = true;
    }
}
