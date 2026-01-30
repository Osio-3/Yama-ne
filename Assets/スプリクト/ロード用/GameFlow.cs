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
        loader.Load("HomeScene");
    }

    public void ContinueGame()
    {
        loader.Load("HomeScene");
    }

    public void BackToStart()
    {
        loader.Load("StartScene");
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
