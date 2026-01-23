using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPanel : MonoBehaviour
{
    [SerializeField] private string animalId; // —á: "Rabbit01"

    void OnEnable()
    {
        if (ChangeUIManager.Instance != null)
        {
            // ƒpƒlƒ‹‚ªo‚½uŠÔ‚É}ŠÓ“o˜^
            ChangeUIManager.Instance.UnlockAnimal(animalId);
        }   
    }
}