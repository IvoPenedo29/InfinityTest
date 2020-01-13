using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        AudioManager.instance.InitAudioManager();
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            print(PlayerPrefs.GetInt("currentLevel"));
        else if (Input.GetKeyDown(KeyCode.Delete))
            PlayerPrefs.DeleteAll();
    }
}
