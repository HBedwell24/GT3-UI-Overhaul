using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    private string lastScene;

    public static AudioManager instance;
    void Awake()
    {
        lastScene = SceneManager.GetActiveScene().name;

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

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        playBackgroundMusic();
    }

    private void playBackgroundMusic()
    {
        if (lastScene.Equals("Simulation Mode"))
        {
            Play("Simulation Mode");
        }
        else if (lastScene.Equals("Go Race"))
        {
            Play("Go Race");
        }
    }

    void Update()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != lastScene)
        {
            lastScene = currentScene;
            playBackgroundMusic();
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }
}
