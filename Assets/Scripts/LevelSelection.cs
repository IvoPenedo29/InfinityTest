using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 0);

        //Bloquear os níveis de acordo com o nível atual
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > currentLevel)
            {
                levelButtons[i].GetComponentInChildren<RawImage>().enabled = true;
                levelButtons[i].interactable = false;
            }                
        }
    }    
}
