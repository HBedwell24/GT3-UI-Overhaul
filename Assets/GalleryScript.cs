using UnityEngine;
using UnityEngine.EventSystems;

public class GalleryScript : MonoBehaviour
{
    [SerializeField]
    public CanvasGroup replayGroup;

    [SerializeField]
    public CanvasGroup musicGroup;

    private GameObject firstMusicButton;

    void Start()
    {
        firstMusicButton = GameObject.Find("Are You");
        firstMusicButton.SetActive(false);

        replayGroup.alpha = 0;
        replayGroup.interactable = false;
        replayGroup.blocksRaycasts = false;

        musicGroup.alpha = 0;
        musicGroup.interactable = false;
        musicGroup.blocksRaycasts = false;
    }

    public void ReplayClicked()
    {
        firstMusicButton.SetActive(false);
        musicGroup.alpha = 0;
        musicGroup.interactable = false;
        musicGroup.blocksRaycasts = false;

        replayGroup.alpha = 1;
        replayGroup.interactable = true;
        replayGroup.blocksRaycasts = true;
    }

    public void MusicClicked()
    {
        firstMusicButton.SetActive(true);
        replayGroup.alpha = 0;
        replayGroup.interactable = false;
        replayGroup.blocksRaycasts = false;

        musicGroup.alpha = 1;
        musicGroup.interactable = true;
        musicGroup.blocksRaycasts = true;
    }
}
