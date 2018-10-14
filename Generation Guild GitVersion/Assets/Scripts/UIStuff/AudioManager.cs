using UnityEngine.Audio;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    public static float storedVol;
    public static float storedSFX;


    void Awake()
    {

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            if (s.name == "Theme")
            {
                storedVol = s.source.volume;
            }

            if (s.name == "TP")
            {
                storedSFX = s.source.volume;
            }
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Play("MMJingle");
        }
        else
        {
            Play("Theme");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
        //Debug.Log("Playing: " + s.name);
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            StopPlaying(s.name);
        }
    }

    public void ChangeVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == "Theme" || s.name == "MMJingle" || s.name == "Pause")
            {
                s.source.volume = volume;
                storedVol = s.source.volume;
            }
        }
    }

    public void ChangeSFX(float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.name != "Theme" && s.name != "MMJingle" && s.name != "Pause" && s.name != "Talking" && s.name != "EE" && s.name != "ShootHook")
            {
                s.source.volume = volume;
                storedSFX = s.source.volume;
            }
        }
    }
}
