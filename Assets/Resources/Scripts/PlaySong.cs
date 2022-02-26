using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySong : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData data)
    {
        Debug.Log(this.gameObject.name + " was selected");
        AudioManager.instance.PlaySoundEffect("Cursor");

        StartCoroutine(WaitForAudio());     
    }

    private IEnumerator WaitForAudio()
    {
        if (gameObject.name.Equals("Mad Skillz"))
        {
            AudioManager.instance.PlayMusic("Mad Skillz");
        }
        else if (gameObject.name.Equals("Are You"))
        {
            AudioManager.instance.PlayMusic("Are You Gonna Go My Way?");
        }
        else if (gameObject.name.Equals("Satisfied"))
        {
            AudioManager.instance.PlayMusic("Satisfied");
        }
        else if (gameObject.name.Equals("Stop the Rock"))
        {
            AudioManager.instance.PlayMusic("Stop The Rock");
        }
        else if (gameObject.name.Equals("Break In"))
        {
            AudioManager.instance.PlayMusic("Break In");
        }
        else if (gameObject.name.Equals("Glowl"))
        {
            AudioManager.instance.PlayMusic("Glowl");
        }
        else
        {
            AudioManager.instance.StopMusic();
        }
        yield return null;
    }
}
