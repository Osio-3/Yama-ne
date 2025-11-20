using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingMenuUI : MonoBehaviour
{
    void OnEnable()
    {
        BGMManager.Instance.RegisterSettingUI(this.gameObject);
    }
}

