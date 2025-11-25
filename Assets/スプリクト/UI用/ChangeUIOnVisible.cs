using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChangeUIOnVisible : MonoBehaviour
{
    private List<Image> targetUIs = new List<Image>();

    void Start()
    {
        // オブジェクト名に対応する UI を全部探す
        string key = gameObject.name + "_UI";

        // シーン内の全オブジェクトを検索
        var allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (var obj in allObjects)
        {
            if (obj.name.StartsWith(key))
            {
                var images = obj.GetComponentsInChildren<Image>(true);
                targetUIs.AddRange(images);
            }
        }
    }

    void OnBecameVisible()
    {
        foreach (var img in targetUIs)
        {
            img.color = Color.white;
        }
    }
}