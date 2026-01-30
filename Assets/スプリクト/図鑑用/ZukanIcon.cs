using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZukanIcon : MonoBehaviour
{
    public string zukanKey;
    private Image img;
    private Color defaultColor;

    void Awake()
    {
        img = GetComponent<Image>();
        defaultColor = img.color; // –¢”­Œ©
    }

    public void Unlock()
    {
        img.color = Color.white;
    }

    public void ResetColor()
    {
        img.color = defaultColor;
    }
}
