using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    List<PlaySong> clickActions = new List<PlaySong>();

    public void addClickAction(PlaySong clickActionToAdd)
    {
        //Adds clickActionToAdd if it does not exist in the List already
        if (!clickActions.Contains(clickActionToAdd))
        {
            clickActions.Add(clickActionToAdd);
        }
    }

    public void removeClickAction(PlaySong clickActionToAdd)
    {
        //Removes clickActionToAdd if it exist in the List 
        if (clickActions.Contains(clickActionToAdd))
        {
            clickActions.Add(clickActionToAdd);
        }
    }

    public bool clickActionExist(PlaySong clickActionToAdd)
    {
        //Removes clickActionToAdd if it exist in the List 
        return clickActions.Contains(clickActionToAdd);
    }

    public void playAudio(AudioSource audSource)
    {
        //Stop Other Audio
        stopAllClickActionAudio();

        //Now, play the one that was passed in
        audSource.Play();
    }

    void stopAllClickActionAudio()
    {
        //Stop Audio on every ClickAction script
        for (int i = 0; i < clickActions.Count; i++)
        {
            //clickActions[i].stopAudio();
        }
    }
}
