using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zukannmana : MonoBehaviour
{
    [SerializeField] private List<GameObject> pages;
    [SerializeField] private List<Button> pageButtons;

    private int nowPage = 0;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color selectedColor = Color.yellow;

    void Start()
    {
        // null デバッグ
        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i] == null)
                Debug.LogError($"pages[{i}] が null です！");
        }

        for (int i = 0; i < pageButtons.Count; i++)
        {
            if (pageButtons[i] == null)
                Debug.LogError($"pageButtons[{i}] が null です！");
        }

        // ボタンにページ移動を登録
        for (int i = 0; i < pageButtons.Count; i++)
        {
            int index = i;
            pageButtons[i].onClick.AddListener(() => GoToPage(index));
        }

        ShowPage(0);
    }

    private void ShowPage(int index)
    {
        // ページ切り替え
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(i == index);
        }

        // ボタン色切り替え
        for (int i = 0; i < pageButtons.Count; i++)
        {
            Button btn = pageButtons[i];
            ColorBlock cb = btn.colors;

            // 選択中なら selectedColor、その他は normalColor
            Color targetColor = (i == index) ? selectedColor : normalColor;

            // 全ての状態の色を上書き
            cb.normalColor = targetColor;
            cb.highlightedColor = targetColor;
            cb.pressedColor = targetColor;
            cb.selectedColor = targetColor;
            cb.disabledColor = targetColor;

            btn.colors = cb;
        }

        nowPage = index;
    }

    public void GoToPage(int index)
    {
        if (index >= 0 && index < pages.Count)
            ShowPage(index);
    }
}
