using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string path;

    void Awake()
    {
        // 保存先（端末ごとに安全な場所）
        path = Application.persistentDataPath + "/save.json";
    }

    //セーブ
    public void SaveGame()
    {
        SaveData data = new SaveData();

        // ここにセーブしたい内容を入れる

        // ★ UI状態を保存
        foreach (var id in ChangeUIManager.Instance.GetAllUnlocked())
        {
            data.unlockedAnimalIds.Add(id);
        }

        // JSON化
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        Debug.Log("セーブ完了");
    }

    // ▼ ロード
    public void LoadGame()
    {
        if (!File.Exists(path))
        {
            Debug.Log("セーブデータがありません");
            return;
        }

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        // UI状態復元
        var dict = new Dictionary<string, bool>();
        foreach (var id in data.unlockedAnimalIds)
        {
            dict[id] = true;
        }

        ChangeUIManager.Instance.SetAllUnlocked(data.unlockedAnimalIds);
        Debug.Log("ロード完了");
    }
}
