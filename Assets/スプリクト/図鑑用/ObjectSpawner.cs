using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objects; // 出現させたいオブジェクト
    public float minX = -8f, maxX = 8f, minY = -4f, maxY = 4f;

    void Start()
    {
        StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 1.0f);
            yield return new WaitForSeconds(waitTime);

            Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject prefab = objects[Random.Range(0, objects.Length)];

            // 正しく生成
            GameObject spawned = Instantiate(prefab, pos, Quaternion.identity);

            // ランダムスケール設定
            float randomScale = Random.Range(0.1f, 0.5f);
            spawned.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

            // UI 連動のために登録
            ChangeUIOnVisible.RegisterObject(spawned);

            // 寿命設定
            float randomLife = Random.Range(2f, 6f);
            Destroy(spawned, randomLife);
        }
    }
}
