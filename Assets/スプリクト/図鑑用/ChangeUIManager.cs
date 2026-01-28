using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIManager : MonoBehaviour
{
    public static ChangeUIManager Instance;

    // UIの表示状態を保存
    private Dictionary<string, bool> encyclopediaUnlocked
        = new Dictionary<string, bool>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // 図鑑登録
    public void UnlockAnimal(string animalId)
    {
        encyclopediaUnlocked[animalId] = true;
    }

    public bool IsAnimalUnlocked(string animalId)
    {
        return encyclopediaUnlocked.ContainsKey(animalId)
            && encyclopediaUnlocked[animalId];
    }

    public Dictionary<string, bool> GetAllUnlocked()
    {
        return encyclopediaUnlocked;
    }

    public void SetAllUnlocked(Dictionary<string, bool> data)
    {
        encyclopediaUnlocked.Clear();
        foreach (var kv in data)
            encyclopediaUnlocked[kv.Key] = kv.Value;
    }

    // はじめから用
    public void ResetAll()
    {
        encyclopediaUnlocked.Clear();
    }
}