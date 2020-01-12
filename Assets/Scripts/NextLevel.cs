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
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        else        
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);                    
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
