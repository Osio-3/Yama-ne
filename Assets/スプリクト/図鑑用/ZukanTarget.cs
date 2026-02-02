using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZukanTarget : MonoBehaviour
{
    public string encyclopediaKey;

    private Image img;
    private Color defaultColor;

    public string animalId;
    private bool registered = false;

    void Awake()
    {
        img = GetComponent<Image>();
        if (img != null)
            defaultColor = img.color;
    }

    void OnEnable()
    {
        Refresh();

        if (registered) return;

        registered = true;
        ChangeUIManager.Instance?.UnlockAnimal(animalId);
    }

    public void Refresh()
    {
        if (ChangeUIManager.Instance == null) return;
        if (!ChangeUIManager.Instance.IsAnimalUnlocked(encyclopediaKey)) return;
        if (img == null) return;

        img.color = defaultColor; // å≥ÇÃêFÇ…ñﬂÇ∑
    }
}
