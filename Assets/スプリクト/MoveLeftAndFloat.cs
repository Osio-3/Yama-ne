using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラが右に進みながら、上下にふわふわ動くスクリプト
/// </summary>
public class MoveLeftAndFloat : MonoBehaviour
{
    [Header("移動速度設定")]
    [Tooltip("右方向の速度（正の値で右に進む）")]
    public float horizontalSpeed = 200f;

    [Tooltip("上昇トレンド速度（正の値で少しずつ上へ）")]
    public float riseSpeed = 20f;

    [Header("ふわふわ設定")]
    [Tooltip("上下の振れ幅（波の高さ）")]
    public float floatAmplitude = 20f;

    [Tooltip("上下の速さ（波の速さ）")]
    public float floatFrequency = 2f;

    [Header("戻る判定")]
    [Tooltip("このX座標を超えたら初期位置に戻る")]
    public float returnX = 516f;

    private RectTransform rect;
    private Vector3 startPos;
    private float startTime;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        startPos = rect.anchoredPosition;
        startTime = Time.time;
    }

    void Update()
    {
        // 右方向に進む
        rect.anchoredPosition += Vector2.right * horizontalSpeed * Time.deltaTime;

        // 上下にふわふわ＋全体的に少しずつ上昇
        float elapsed = Time.time - startTime;
        float newY = startPos.y
            + Mathf.Sin(elapsed * floatFrequency) * floatAmplitude
            + (riseSpeed * elapsed * 0.1f);

        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, newY);

        // 指定X超えたらリセット
        if (rect.anchoredPosition.x >= returnX)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        rect.anchoredPosition = startPos;
        startTime = Time.time; // ふわふわの位相もリセット
    }
}
