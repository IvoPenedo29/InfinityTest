using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public Sound[] sounds;

    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate<GameObject>(Resources.Load<GameObject>("Audio Manager")).GetComponent<AudioManager>();

            return _instance;
        }
    }

    public void InitAudioManager()
    {
        return;
    }

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Stop();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return false;

        return s.source.isPlaying;
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Pause();
    }

    public void Continue(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.UnPause();
    }
}
