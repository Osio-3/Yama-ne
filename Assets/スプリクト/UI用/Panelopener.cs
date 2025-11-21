using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panelopener : MonoBehaviour
{
    [SerializeField] private GameObject targetPanel;

    public void OpenPanel()
    {
        //‘¼‚Ìƒpƒlƒ‹‚Í•Â‚¶‚Ä‚¨‚­
        PanelManager.Instance.OpenOnly(targetPanel);
    }
}
