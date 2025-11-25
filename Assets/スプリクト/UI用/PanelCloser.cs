using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCloser : MonoBehaviour
{
    [SerializeField] private GameObject targetPanel;

    public void Close()
    {
        PanelManager.Instance.ClosePanel(targetPanel);
    }
}

