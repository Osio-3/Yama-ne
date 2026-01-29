using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIManager : MonoBehaviour
{
    public static ChangeUIManager Instance;

    // UIの表示状態を保存
    private Dictionary<string, bool> encyclopediaUnlocked
        = new Dictionary<string, bool>();
    private HashSet<string> unlockedAnimals = new HashSet<string>();

    void Awake()
    {
        //Debug.Log("ChangeUIManager Awake: " + GetInstanceID());

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 図鑑登録
    public void UnlockAnimal(string animalId)
    {
        //Debug.Log("UnlockAnimal: " + animalId + " / InstanceID: " + GetInstanceID());
        unlockedAnimals.Add(animalId);
    }

    public bool IsAnimalUnlocked(string animalId)
    {
        bool result = unlockedAnimals.Contains(animalId);
        //Debug.Log("IsUnlocked: " + animalId + " = " + result + " / InstanceID: " + GetInstanceID());
        return result;
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