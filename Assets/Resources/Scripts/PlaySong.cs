using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySong : MonoBehaviour, ISelectHandler
{
    public AudioClip areYouGonna;
    public AudioClip satisfied;
    public AudioClip stopTheRock;
    public AudioClip madSkillz;
    public AudioClip breakIn;
    public AudioClip glowl;
    public AudioClip cursorSound;

    public AudioSource audioSource;

    public void OnSelect(BaseEventData data)
    {
        Debug.Log(this.gameObject.name + " was selected");

        audioSource.clip = cursorSound;
        audioSource.Play();

        StartCoroutine(WaitForAudio(cursorSound));     
    }

    private IEnumerator WaitForAudio(AudioClip clip)
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        if (gameObject.name.Equals("Mad Skillz"))
        {
            audioSource.Stop();
            audioSource.clip = madSkillz;
            audioSource.Play();
        }
        else if (gameObject.name.Equals("Are You"))
        {
            audioSource.Stop();
            audioSource.clip = areYouGonna;
            audioSource.Play();
        }
        else if (gameObject.name.Equals("Satisfied"))
        {
            audioSource.Stop();
            audioSource.clip = satisfied;
            audioSource.Play();
        }
        else if (gameObject.name.Equals("Stop the Rock"))
        {
            audioSource.Stop();
            audioSource.clip = stopTheRock;
            audioSource.Play();
        }
        else if (gameObject.name.Equals("Break In"))
        {
            audioSource.Stop();
            audioSource.clip = breakIn;
            audioSource.Play();
        }
        else if (gameObject.name.Equals("Glowl"))
        {
            audioSource.Stop();
            audioSource.clip = glowl;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
