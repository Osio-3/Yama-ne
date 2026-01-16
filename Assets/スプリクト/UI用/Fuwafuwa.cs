using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuwafuwa : MonoBehaviour
{
    public float amplitude = 10f;   // 上下の幅（px）
    public float speed = 1f;        // ふわふわの速さ
    public float moveUpSpeed = 25f; // 上に移動する速度
    public float resetY = 650f;      // このY座標を超えたらリセット

    private Vector3 startPos;        // 現在の基準位置
    private Vector3 initialPos;      // 初期位置

    void Start()
    {
        initialPos = transform.localPosition;
        startPos = initialPos;
    }

    void Update()
    {
        startPos += Vector3.up * moveUpSpeed * Time.deltaTime;

        float y = Mathf.Sin(Time.time * speed) * amplitude;
        transform.localPosition = startPos + Vector3.up * y;

        // 指定Yを超えたら初期位置に戻す
        if (startPos.y >= resetY)
        {
            startPos = initialPos;
        }
    }
}
