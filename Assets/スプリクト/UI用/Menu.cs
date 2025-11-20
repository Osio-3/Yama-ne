using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button menuButton;
    private MenuUI pauseMenu;

    void Awake()
    {
        // 同じタイプのオブジェクトが既にあれば削除
        if (FindObjectsOfType<Menu>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // シーン上の MenuUI を探す
        pauseMenu = FindObjectOfType<MenuUI>();

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
