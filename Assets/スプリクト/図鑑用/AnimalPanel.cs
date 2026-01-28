using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPanel : MonoBehaviour
{
    [SerializeField] private string animalId; // ó·: "Rabbit01"

    void OnEnable()
    {
        if (ChangeUIManager.Instance == null) return;

        // ê}ä”ìoò^
        ChangeUIManager.Instance.UnlockAnimal(animalId);
        //Debug.Log("Unlock åƒÇ—èoÇµ: " + animalId);

        // Åö ê}ä”UIÇçXêV
        RefreshZukanUI();
    }

    void RefreshZukanUI()
    {
        var icons = FindObjectsOfType<EncyclopediaIcon>(true);

        foreach (var icon in icons)
        {
            icon.Refresh();
        }
    }
}