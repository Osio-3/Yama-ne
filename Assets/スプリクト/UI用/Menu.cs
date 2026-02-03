using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button menuButton;
    private MenuUI pauseMenu;

    void Start()
    {
        // シーン上の MenuUI を探す
        pauseMenu = FindObjectOfType<MenuUI>();

        if (pauseMenu == null)
        {
            Debug.LogError("MenuUI が見つかりません。常駐オブジェクトを確認してください。");
            return;
        }

        // ボタンイベント登録
        menuButton.onClick.AddListener(OnMenuButtonClicked);
    }

    void OnMenuButtonClicked()
    {
        if (pauseMenu == null)
        {
            Debug.LogWarning("PauseMenuUI が見つかりません。シーンに配置してください。");
            return;
        }

        // 既に開いているか確認して切り替え
        if (pauseMenu.IsMenuOpen())
        {
            pauseMenu.ClosePauseMenu();
        }
        else
        {
            pauseMenu.OpenPauseMenu();
        }
    }
}
