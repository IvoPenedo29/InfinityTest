using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        AudioManager.instance.InitAudioManager();
        AdManager.instance.InitAdManager();
        AudioManager.instance.Play("Background Music");
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
