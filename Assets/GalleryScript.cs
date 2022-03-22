using UnityEngine;

public class GalleryScript : MonoBehaviour
{
    [SerializeField]
    public CanvasGroup replayGroup;

    [SerializeField]
    public CanvasGroup musicGroup;


    void Start()
    {
        replayGroup.alpha = 0;
        replayGroup.interactable = false;
        replayGroup.blocksRaycasts = false;

        musicGroup.alpha = 0;
        musicGroup.interactable = false;
        musicGroup.blocksRaycasts = false;
    }

    public void ReplayClicked()
    {
        musicGroup.alpha = 0;
        musicGroup.interactable = false;
        musicGroup.blocksRaycasts = false;

        replayGroup.alpha = 1;
        replayGroup.interactable = true;
        replayGroup.blocksRaycasts = true;
    }

    public void MusicPlayed()
    {
        replayGroup.alpha = 0;
        replayGroup.interactable = false;
        replayGroup.blocksRaycasts = false;

        musicGroup.alpha = 1;
        musicGroup.interactable = true;
        musicGroup.blocksRaycasts = true;
    }
}
