using System.Collections;
using UnityEngine;

public class WidgetScrollAnim : MonoBehaviour
{
    public AudioSource subMenuEnter;
    public AudioSource subMenuExit;

    public GameObject widget;

    [SerializeField]
    public CanvasGroup singlePlayer;

    [SerializeField]
    public CanvasGroup partyPlay;

    public void ShowHideMenu()
    {
        if (widget != null)
        {
            Animator animator = widget.GetComponent<Animator>();
            if (animator != null)
            {
                bool wasScrolled = animator.GetBool("show");
                animator.SetBool("show", !wasScrolled);

                StartCoroutine(PlaySound(wasScrolled));

                singlePlayer.interactable = false;
                partyPlay.interactable = false;
            }
        }
    }

    IEnumerator PlaySound(bool isOpen)
    {

        // fade from opaque to transparent
        if (isOpen)
        {
            subMenuEnter.Play();
            yield return new WaitWhile(() => subMenuExit.isPlaying);
        }
        // fade from transparent to opaque
        else
        {
            subMenuExit.Play();
            yield return new WaitWhile(() => subMenuEnter.isPlaying);
        }
    }
}