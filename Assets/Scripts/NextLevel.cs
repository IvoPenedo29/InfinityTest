using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int _nextLevel;

    void Start()
    {
        _nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 11)
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        else
        {
            print(_nextLevel);
            int currentLevel = PlayerPrefs.GetInt("currentLevel");
            print(currentLevel);

            SceneManager.LoadScene(_nextLevel, LoadSceneMode.Single);

            if (_nextLevel > PlayerPrefs.GetInt("currentLevel"))
            {                
                PlayerPrefs.SetInt("currentLevel", _nextLevel - 1);
            }                            
        }        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
