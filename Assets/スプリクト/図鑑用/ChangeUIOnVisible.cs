using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIOnVisible : MonoBehaviour
{
    private static List<GameObject> spawnedObjects = new List<GameObject>();
    private List<Image> targetUIs = new List<Image>();

    public static void RegisterObject(GameObject obj)
    {
        // 登録時に UI を探して追加
        string key = obj.name + "_UI";

        var allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var o in allObjects)
        {
            if (o.name.StartsWith(key))
            {
                var images = o.GetComponentsInChildren<Image>(true);
                foreach (var img in images)
                {
                    // obj にアタッチされてる ChangeUIOnVisible を取得
                    var script = obj.GetComponent<ChangeUIOnVisible>();
                    if (script != null)
                    {
                        script.targetUIs.Add(img);
                    }
                }
            }
        }

        spawnedObjects.Add(obj);
    }

    void Start()
    {
        // シーンに最初からあるオブジェクト向け
        string key = gameObject.name + "_UI";

        var allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var o in allObjects)
        {
            if (o.name.StartsWith(key))
            {
                var images = o.GetComponentsInChildren<Image>(true);
                targetUIs.AddRange(images);
            }
        }

        // ▼ セーブ状態反映
        foreach (var img in targetUIs)
        {
            if (ChangeUIManager.Instance != null &&
                ChangeUIManager.Instance.IsAnimalUnlocked(gameObject.name))
            {
                img.color = Color.white;
            }
        }
    }

    void OnBecameVisible()
    {
        // ★ パネルが見えた瞬間に図鑑登録
        if (ChangeUIManager.Instance != null)
        {
            ChangeUIManager.Instance.UnlockAnimal(gameObject.name);
        }

        // 図鑑UIを白く
        foreach (var img in targetUIs)
        {
            img.color = Color.white;
        }
    }
}