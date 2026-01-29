using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private Slider slider;
    [SerializeField] private float minLoadingTime = 5f;

    public void Load(string sceneName)
    {
        loadingUI.SetActive(true);
        StartCoroutine(LoadCoroutine(sceneName));
    }

    IEnumerator LoadCoroutine(string sceneName)
    {
        float elapsed = 0f;
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while (elapsed < minLoadingTime || async.progress < 0.9f)
        {
            elapsed += Time.unscaledDeltaTime;
            slider.value = Mathf.Min(async.progress / 0.9f, elapsed / minLoadingTime);
            yield return null;
        }

        async.allowSceneActivation = true;
    }
}
