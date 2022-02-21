using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaySong : MonoBehaviour, ISelectHandler
{
    public AudioSource areYouGonna;
    public AudioSource satisfied;
    public AudioSource stopTheRock;
    public AudioSource madSkillz;
    public AudioSource breakIn;
    public AudioSource glowl;

    void Start()
    {
        
    }

    public void OnSelect(BaseEventData data)
    {
        Debug.Log(this.gameObject.name + " was selected");
        if (gameObject.name.Equals("Mad Skillz"))
        {
            madSkillz.Play();
        }
        else if (gameObject.name.Equals("Are You"))
        {
            areYouGonna.Play();
        }
        else if (gameObject.name.Equals("Satisfied"))
        {
            satisfied.Play();
        }
        else if (gameObject.name.Equals("Stop The Rock"))
        {
            stopTheRock.Play();
        }
        else if (gameObject.name.Equals("Break In"))
        {
            breakIn.Play();
        }
        else if (gameObject.name.Equals("Glowl"))
        {
            glowl.Play();
        }
    }
    public void OnDeselect(BaseEventData data)
    {
        
    }

    void Update()
    {
        
    }
}
