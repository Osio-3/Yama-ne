using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private LoadingScene loader;

    public void StartNewGame()
    {
        ChangeUIManager.Instance?.ResetAll();
        DeleteSave();
        FindObjectOfType<LoadingScene>().Load("HomeScene");
    }

    public void ContinueGame()
    {
        FindObjectOfType<LoadingScene>().Load("HomeScene");
    }

    public void BackToStart()
    {
        FindObjectOfType<LoadingScene>().Load("StartScene");
    }

    public void StartStroll()
    {
        loader.Load("StrollScene");
    }

    void DeleteSave()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
            File.Delete(path);
    }
}
