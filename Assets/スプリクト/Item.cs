using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] itemPrefabs;

    [Header("出現設定")]
    public float spawnInterval = 1.0f;
    public int spawnCount = 1;

    [Header("完全ランダム設定")]
    public float minRadius = 3f;   // 最低距離
    public float maxRadius = 8f;   // 最大距離（広がり）
    public float forwardBias = 0.7f; // 前方に出やすくする値（0?1）

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnItems();
        }
    }

    void SpawnItems()
    {
        // プレイヤーの向き
        bool facingRight = player.localScale.x > 0;

        for (int i = 0; i < spawnCount; i++)
        {
            // ★ どの方向に出すか、角度をランダム決定
            float angle = Random.Range(-90f * forwardBias, 90f * forwardBias); // 前方向に寄せる
            if (!facingRight) angle += 180f; // 左を向いてるとき反転

            // ★ 距離をランダム（最小?最大の間）
            float dist = Random.Range(minRadius, maxRadius);

            // ★ 角度＋距離で出現位置を作る（これが超自然）
            Vector3 offset = new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad) * dist,
                Mathf.Sin(angle * Mathf.Deg2Rad) * dist,
                0
            );

            // プレイヤー位置＋ランダムオフセット
            Vector3 spawnPos = player.position + offset;

            // ランダムアイテム
            GameObject prefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }
}
