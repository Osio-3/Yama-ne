using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaIcon : MonoBehaviour
{
    public string animalId;
    public Image iconImage;

    void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        bool unlocked =
            ChangeUIManager.Instance != null
            && ChangeUIManager.Instance.IsAnimalUnlocked(animalId);

        if (unlocked)
        {
            iconImage.color = Color.white;
        }
    }
}
