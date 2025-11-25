using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;

    [SerializeField] private List<GameObject> panels;

    void Awake()
    {
        Instance = this;
    }

    public void OpenOnly(GameObject panel)
    {
        foreach (var p in panels)
            p.SetActive(false);

        panel.SetActive(true);
    }

    // ★閉じる用メソッドを追加
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
