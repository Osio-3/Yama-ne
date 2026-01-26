using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZukanTarget : MonoBehaviour
{
    public string encyclopediaKey;

    private Image img;
    private Color defaultColor;

    void Awake()
    {
        img = GetComponent<Image>();
        if (img != null)
            defaultColor = img.color;
    }

    void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (ChangeUIManager.Instance == null) return;
        if (!ChangeUIManager.Instance.IsAnimalUnlocked(encyclopediaKey)) return;
        if (img == null) return;

        // 元の色を使う（白固定しない）
        img.color = new Color(
            defaultColor.r,
            defaultColor.g,
            defaultColor.b,
            defaultColor.a
        );
    }
}
