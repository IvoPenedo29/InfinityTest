using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    private Dictionary<string, string> localizedText;
    private bool _isReady = false;
    private string _missingTextString = "Localized text not found";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        //Detetar se o jogo está a ser jogado no android ou no iOS e ir buscar os ficheiros json nos dispositivos, senão ir buscar da maneira correta para a versão desktop
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }

            string jsonString = reader.text;

            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(jsonString);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }
        }
        else
        {
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

                for (int i = 0; i < loadedData.items.Length; i++)
                {
                    localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
                }
            }
        }        

        _isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        //Trocar os valores dos textos de acordo com a língua selecionada
        string result = _missingTextString;
        if (localizedText.ContainsKey(key))
            result = localizedText[key];

        return result;
    }

    public bool GetIsReady()
    {
        return _isReady;
    }
}
