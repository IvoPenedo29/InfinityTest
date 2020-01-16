using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public Sound[] sounds;

    //Criar uma instância da classe para que seja facilmente acessível pelas outras classes
    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate<GameObject>(Resources.Load<GameObject>("Audio Manager")).GetComponent<AudioManager>();

            return _instance;
        }
    }

    //Função de inicialização da classe
    public void InitAudioManager()
    {
        return;
    }

    void Awake()
    {
        //Definir as variáveis no array de sons
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

    //Função para fazer play do som introduzido na função
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Play();
    }

    //Função para fazer stop do som introduzido na função
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Stop();
    }

    //Função para verificar se o som introduzido na função está a ser played
    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return false;

        return s.source.isPlaying;
    }

    //Função para fazer pause do som introduzido na função
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Pause();
    }

    //Função para fazer continue do som introduzido na função
    public void Continue(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.UnPause();
    }
}
