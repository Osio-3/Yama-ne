using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;
    [SerializeField] private float minLoadingTime = 5.0f; // ç≈í·ï\é¶éûä‘

    public void LoadNextScene()
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
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
