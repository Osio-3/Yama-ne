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

        // ★ ここにセーブしたい内容を入れる
        data.stage = 3;
        data.hp = 50;
        data.coin = 120;

        // JSON化
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
        Debug.Log("セーブ完了: " + path);
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

        Debug.Log("ロード完了");
        Debug.Log("stage: " + data.stage);
        Debug.Log("hp: " + data.hp);
        Debug.Log("coin: " + data.coin);

        // ★ここでゲーム側の変数に反映させる
        // player.hp = data.hp;
        // gameManager.stage = data.stage;
        // etc.
    }
}
