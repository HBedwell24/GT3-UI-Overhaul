using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : Selectable
{
    public AudioSource menuScroll;
    public AudioSource menuSelection;
    public AudioSource menuExit;
    public AudioSource accessDenied;
    public AudioSource cursor;
    public AudioSource subMenuEnter;
    public AudioSource subMenuExit;

    public void playMenuScroll()
    {
        menuScroll.Play();
    }

    IEnumerator playSound(AudioSource audioSource)
    {
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
    }

    public void playMenuSelection()
    {
        StartCoroutine(playSound(menuSelection));
    }

    public void playMenuExit()
    {
        StartCoroutine(playSound(menuExit));
    }

    public void playAccessDenied()
    {
        accessDenied.Play();
    }

    public void playCursor()
    {
        cursor.Play();
    }

    public void playSubMenuEnter()
    {
        subMenuEnter.Play();
    }

    public void playSubMenuExit()
    {
        subMenuExit.Play();
    }
}
