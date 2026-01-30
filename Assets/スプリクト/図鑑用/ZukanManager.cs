using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZukanManager : MonoBehaviour
{
    public static ZukanManager Instance;

    private Dictionary<string, ZukanIcon> icons = new();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (var icon in FindObjectsOfType<ZukanIcon>(true))
        {
            icons[icon.zukanKey] = icon;
        }
    }

    public void Unlock(string key)
    {
        if (icons.TryGetValue(key, out var icon))
        {
            icon.Unlock();
        }
        else
        {
            Debug.LogWarning($"ZukanIcon not found: {key}");
        }
    }
}
