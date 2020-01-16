using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        //Inicializar variáveis
        AudioManager.instance.InitAudioManager();
        AdManager.instance.InitAdManager();
        AudioManager.instance.Play("Background Music");
    }

    //Função para começar o nível introduzido
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
    
    //Função para sair do jogo
    public void ExitGame()
    {
        Application.Quit();
    }
}
