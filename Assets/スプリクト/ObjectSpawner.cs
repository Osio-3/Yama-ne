using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objects; // 出現させたいオブジェクト
    public float minX = -8f, maxX = 8f, minY = -4f, maxY = 4f;
    public float lifeTime = 5f; // 👈 オブジェクトの寿命（秒）

    void Start()
    {
        StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        while (true)
        {
            float waitTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(waitTime);

            Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject obj = objects[Random.Range(0, objects.Length)];

            GameObject spawned = Instantiate(obj, pos, Quaternion.identity);

            float randomLife = Random.Range(2f, 6f);
            Destroy(spawned, randomLife);
        }
    }
}
