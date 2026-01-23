using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;
    [SerializeField] private float minLoadingTime = 5.0f; // 最低表示時間

    private bool isNewGame = false;

    // ▼ つづきから
    public void LoadNextScene()
    {
        isNewGame = false;
        _loadingUI.SetActive(true);
        StartCoroutine(LoadScene());
    }

    // ▼ はじめから
    public void StartNewGame()
    {
        isNewGame = true;
        _loadingUI.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        // ★ はじめから時の初期化
        if (isNewGame)
        {
            // UI Manager 初期化
            if (ChangeUIManager.Instance != null)
                ChangeUIManager.Instance.ResetAll();

            // セーブ削除
            string path = Application.persistentDataPath + "/save.json";
            if (File.Exists(path))
                File.Delete(path);
        }

        float elapsed = 0f;
        AsyncOperation async = SceneManager.LoadSceneAsync("HomeScene");
        async.allowSceneActivation = false;

        while (elapsed < minLoadingTime || async.progress < 0.9f)
        {
            elapsed += Time.unscaledDeltaTime;

            float progress = Mathf.Min(async.progress / 0.9f, elapsed / minLoadingTime);
            _slider.value = progress;

            yield return null;
        }

        async.allowSceneActivation = true;
    }
}
