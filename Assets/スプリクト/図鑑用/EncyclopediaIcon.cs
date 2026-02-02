using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaIcon : MonoBehaviour
{
    public string animalId;
    public Image iconImage;

    private Color defaultColor;

    void Awake()
    {
        if (iconImage == null)
            iconImage = GetComponent<Image>();

        defaultColor = iconImage.color; // èâä˙êFÇï€ë∂
    }

    void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        //Debug.Log("Refresh Icon: " + animalId);

        if (ChangeUIManager.Instance == null) return;

        bool unlocked = ChangeUIManager.Instance.IsAnimalUnlocked(animalId);
        iconImage.color = unlocked ? Color.white : defaultColor;
        //Debug.Log($"{animalId} unlocked = {unlocked}");
    }
}
