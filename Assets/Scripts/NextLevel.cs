using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [HideInInspector]
    public int nextLevel;

    void Start()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            if (AudioManager.instance.IsPlaying("Victory FX"))
                AudioManager.instance.Stop("Victory FX");

            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WebGLPlayer)
                SceneManager.LoadScene("Main Menu Standalone", LoadSceneMode.Single);
            else
            {
                if (AdManager.instance.adReady)
                {
                    AdManager.instance.ShowPopUp();
                    AdManager.instance.adReady = false;
                }

                SceneManager.LoadScene("Main Menu Smartphone", LoadSceneMode.Single);
            }
        }
        else
        {
            if (AudioManager.instance.IsPlaying("Victory FX"))
                AudioManager.instance.Stop("Victory FX");

            if (AdManager.instance.adReady)
            {
                AdManager.instance.ShowPopUp();
                AdManager.instance.adReady = false;
            }

            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);                    
        }
    }

    public void LoadMainMenu()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WebGLPlayer)
        {
            if (AudioManager.instance.IsPlaying("Victory FX"))
                AudioManager.instance.Stop("Victory FX");

            SceneManager.LoadScene("Main Menu Standalone", LoadSceneMode.Single);
        }
        else
        {
            if (AudioManager.instance.IsPlaying("Victory FX"))
                AudioManager.instance.Stop("Victory FX");

            if (AdManager.instance.adReady)
            {
                AdManager.instance.ShowPopUp();
                AdManager.instance.adReady = false;
            }

            SceneManager.LoadScene("Main Menu Smartphone", LoadSceneMode.Single);
        }
    }
}
