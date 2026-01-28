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
        Debug.Log("AnimalPanel ï\é¶: " + animalId);

        // Åö ê}ä”UIÇçXêV
        RefreshZukanUI();
    }

    void RefreshZukanUI()
    {
        var targets = FindObjectsOfType<ZukanTarget>(true);

        foreach (var t in targets)
        {
            if (t.encyclopediaKey == animalId)
            {
                t.Refresh(); // Ç±ÇÃImageÇæÇØîíÇ≠Ç»ÇÈ
            }
        }
    }
}