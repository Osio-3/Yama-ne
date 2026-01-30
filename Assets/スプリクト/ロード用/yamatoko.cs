using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yamatoko : MonoBehaviour
{
    [Header("アニメ")]
    public Image image;
    public Sprite[] frames;
    public float frameRate = 0.1f;

    [Header("移動")]
    public float moveSpeed = 100f;      // 右に進む速さ（UIなのでpx/s）
    public float goalX = 570f;           // ここまで行ったら戻る

    Coroutine coroutine;
    Vector3 startPos;

    void Awake()
    {
        startPos = transform.localPosition; // 初期位置を保存
    }

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

    void Update()
    {
        MoveRight();
    }

    void MoveRight()
    {
        transform.localPosition += Vector3.right * moveSpeed * Time.deltaTime;

        // 指定座標まで行ったら初期位置に戻す
        if (transform.localPosition.x >= goalX)
        {
            transform.localPosition = startPos;
        }
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
