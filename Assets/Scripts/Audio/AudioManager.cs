using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, Sonidos => Sonidos.name == name);
        s.source.Stop();
    }

    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, Sonidos => Sonidos.name == name);
        if (s.source.mute == true) { s.source.mute = false; }
        else { s.source.mute = true; }
    }

    public void Force_Play(string name)
    {
        Sound s = Array.Find(sounds, Sonidos => Sonidos.name == name);
        s.source.mute = false;
    }

    public void Set_Volume(string name, float _volume)
    {
        Sound s = Array.Find(sounds, Sonidos => Sonidos.name == name);
        s.source.volume = _volume;
    }
}
