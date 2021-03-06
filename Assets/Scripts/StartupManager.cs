﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupManager : MonoBehaviour
{
    public GameObject selectLanguagePanel;
    public GameObject mainPanel;

    //Verificar se os ficheiros json foram carregados e apenas mostrar o menu após sucesso
    private IEnumerator Start()
    {
        while (!LocalizationManager.instance.GetIsReady())
        {
            yield return null;
        }        

        ShowMenu();
    }

    void ShowMenu()
    {
        selectLanguagePanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
