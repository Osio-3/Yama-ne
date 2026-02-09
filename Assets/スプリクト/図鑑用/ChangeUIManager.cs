using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIManager : MonoBehaviour
{
    public static ChangeUIManager Instance;

    // UIの表示状態を保存
    //private Dictionary<string, bool> encyclopediaUnlocked
        //= new Dictionary<string, bool>();
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
        return unlockedAnimals.Contains(animalId);
        //bool result = unlockedAnimals.Contains(animalId);
        //Debug.Log("IsUnlocked: " + animalId + " = " + result + " / InstanceID: " + GetInstanceID());
        //return result;
    }

    /*public Dictionary<string, bool> GetAllUnlocked()
    {
        return encyclopediaUnlocked;
    }*/

    public HashSet<string> GetAllUnlocked()
    {
        return unlockedAnimals;
    }

    public void SetAllUnlocked(List<string> ids)
    {
        unlockedAnimals.Clear();
        foreach (var id in ids)
        {
            unlockedAnimals.Add(id);
        }

        // アイコン更新
        var icons = FindObjectsOfType<EncyclopediaIcon>(true);
        foreach (var icon in icons)
        {
            icon.Refresh();
        }
    }

    // はじめから用
    public void ResetAll()
    {
        // データリセット
        //encyclopediaUnlocked.Clear();
        unlockedAnimals.Clear();

        // 図鑑アイコンを全て初期色に戻す
        var icons = FindObjectsOfType<EncyclopediaIcon>(true);
        foreach (var icon in icons)
        {
            icon.Refresh();
        }

        Debug.Log("ChangeUIManager: ResetAll 完了");
    }
}