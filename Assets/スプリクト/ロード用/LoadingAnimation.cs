using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnimation : MonoBehaviour
{
    public Image image;
    public Sprite[] frames;
    public float frameRate = 0.1f;

    Coroutine coroutine;

    void OnEnable()
    {
        if (image == null || frames.Length == 0) return;
        coroutine = StartCoroutine(Play());
    }

    void OnDisable()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    IEnumerator Play()
    {
        int index = 0;
        while (true)
        {
            image.sprite = frames[index];
            index = (index + 1) % frames.Length;
            yield return new WaitForSecondsRealtime(frameRate);
        }
    }
}
