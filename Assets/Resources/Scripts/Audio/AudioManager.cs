using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] backgroundMusic;
    public Sound[] soundEffects;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in backgroundMusic)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in soundEffects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(backgroundMusic, sound => sound.name == name);

        if (!s.source.isPlaying)
        {
            foreach (Sound sound in backgroundMusic)
            {
                sound.source.Stop();
            }
            s.source.clip = s.clip;
            s.source.Play();
        }
    }

    public void StopMusic()
    {
        foreach (Sound sound in backgroundMusic)
        {
            sound.source.Stop();
        }
    }

    public void PlaySoundEffect(string name)
    {
        Sound s = Array.Find(soundEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.PlayOneShot(s.clip);      
    }
}
