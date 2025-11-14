using UnityEngine;

/// <summary>
/// キャラが左に進みながら、上下にふわふわ動くスクリプト
/// </summary>
public class MoveLeftAndFloat : MonoBehaviour
{
    [Header("移動速度設定")]
    [Tooltip("左方向の速度（正の値で左に進む）")]
    public float horizontalSpeed = 2f;

    [Tooltip("上昇トレンド速度（正の値で少しずつ上へ）")]
    public float riseSpeed = 0.2f;

    [Header("ふわふわ設定")]
    [Tooltip("上下の振れ幅（波の高さ）")]
    public float floatAmplitude = 0.5f;

    [Tooltip("上下の速さ（波の速さ）")]
    public float floatFrequency = 2f;

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // 左方向に進む
        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);

        // 上下にふわふわ＋全体的に少しずつ上昇
        float newY = startY + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude + (riseSpeed * Time.time * 0.1f);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
