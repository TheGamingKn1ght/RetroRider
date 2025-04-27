using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

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
    }

    private void Start()
    {
        PlayMusic("Main");
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        musicSource.clip = sound.clip;
        musicSource.Play();
    }

    public void PauseMusic(bool pause)
    {
        if (pause)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.Play();
        }
    }

    public void RestartMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        musicSource.clip = sound.clip;
        musicSource.Stop();
        musicSource.Play();
    }


    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }
}