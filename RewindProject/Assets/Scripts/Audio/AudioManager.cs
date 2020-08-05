﻿using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds; //adding new audio in the inspector

    public static AudioManager instanse; 
    void Awake()
    {
        if (instanse == null)// to check that only one Audio Manager is in the seen
        { instanse = this; }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in Sounds)//set all values for variables from inspector
        {
            s.sourse = gameObject.AddComponent<AudioSource>();
            s.sourse.clip = s.clip;

            s.sourse.volume = s.volume;
            s.sourse.pitch = s.pitch;

            s.sourse.loop = s.loop;
        }
    }

    public void Play(string name) //function for external call it should be: FindGameObjectOfType<AudioManager>.Play("name_of_sound")
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("The Sound with name: " + name + " wasn't found.");
            return;
        }
        s.sourse.Play();
    }

    public void Stop(string name) //function for external call it should be: FindGameObjectOfType<AudioManager>.Play("name_of_sound")
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("The Sound with name: " + name + " wasn't found.");
            return;
        }
        s.sourse.Stop();
    }

    public void StopAllSounds() //function for external call it should be: FindGameObjectOfType<AudioManager>.Play("name_of_sound")
    {
        foreach (Sound s in Sounds)//set all values for variables from inspector
        {
            if(s.name != "MainTheme")
            {
                s.sourse.Stop();
            }

        }
    }

    public void PauseAllSounds() //function for external call it should be: FindGameObjectOfType<AudioManager>.Play("name_of_sound")
    {
        foreach (Sound s in Sounds)//set all values for variables from inspector
        {
            if (s.name != "MainTheme")
            {
                if (IsSoundIsPlayingNow(s.name))
                {
                    s.WasPaused = true;
                    s.sourse.Pause();
                }
            }
        }
    }

    public void ResumePausedSounds() //function for external call it should be: FindGameObjectOfType<AudioManager>.Play("name_of_sound")
    {
        foreach (Sound s in Sounds)//set all values for variables from inspector
        {
            if (s.name != "MainTheme")
            {
                if (s.WasPaused == true)
                {
                    s.WasPaused = false;
                    s.sourse.Play();
                }
            }
        }
    }

    public bool IsSoundIsPlayingNow(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("The Sound with name: " + name + " wasn't found.");
            return false;
        }

        return s.sourse.isPlaying;
    }

}
