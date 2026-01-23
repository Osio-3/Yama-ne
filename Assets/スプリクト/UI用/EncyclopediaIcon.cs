using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaIcon : MonoBehaviour
{
    public string animalId;
    public Image iconImage;

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (ChangeUIManager.Instance == null) return;

        if (ChangeUIManager.Instance.IsAnimalUnlocked(animalId))
        {
            iconImage.color = Color.white;
        }
    }
}
