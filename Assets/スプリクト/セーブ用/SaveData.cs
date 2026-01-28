using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //セーブしたい内容
    //public int stage;
    //public int hp;
    //public int coin;

    // UI表示状態
    public List<string> uiKeys = new List<string>();
    public List<bool> uiValues = new List<bool>();
    public List<string> unlockedAnimalIds = new List<string>();
}
