using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject menuUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject menuUIInstance;
    // ボタンのリストを保持
    private List<Button> menuButtons = new List<Button>();
    private int currentSelectedIndex = 0;

    // メニューを開く
    public void OpenPauseMenu()
    {
        if (menuUIInstance != null) return;

        menuUIInstance = Instantiate(menuUIPrefab);

        // 現在のシーン名を取得
        string currentScene = SceneManager.GetActiveScene().name;

        // ★ スタートシーン以外なら時間を止める
        if (currentScene != "StartScene")
        {
            Time.timeScale = 0f;
        }

        // メニュー内のボタンを取得（必要なら使う）
        menuButtons.Clear();
        Button[] buttons = menuUIInstance.GetComponentsInChildren<Button>();
        menuButtons.AddRange(buttons);

        // ★ CloseButton を探してイベント登録
        foreach (Button btn in buttons)
        {
            if (btn.name == "modoru")  // ← Unity でのボタン名と一致させてね！
            {
                btn.onClick.AddListener(() =>
                {
                    ClosePauseMenu();
                });
            }
        }

    }

    // メニューを閉じる
    public void ClosePauseMenu()
    {
        if (menuUIInstance == null) return;

        Destroy(menuUIInstance);

        // ★ スタートシーン以外のときだけ時間を再開
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != "StartScene")
        {
            Time.timeScale = 1f;
        }

        menuButtons.Clear();
    }

    // 開いているか判定
    public bool IsMenuOpen()
    {
        return menuUIInstance != null;
    }
}
