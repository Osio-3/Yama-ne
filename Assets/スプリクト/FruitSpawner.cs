using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits;

    public float spawnInterval = 1.5f;

    public float minY = -3f; // ランダムY
    public float maxY = 3f;

    public float minSpeed = 2f;
    public float maxSpeed = 6f;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        InvokeRepeating("SpawnFruit", 1f, spawnInterval);
    }

    void SpawnFruit()
    {
        // ★ カメラ右端（画面外）を計算
        float camRight = cam.transform.position.x + cam.orthographicSize * cam.aspect + 1f;
        // 「+1f」は完全に画面外にするための余白

        // Y をランダムに
        float y = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(camRight, y, 0);

        // ランダムフルーツ生成
        GameObject fruit = Instantiate(
            fruits[Random.Range(0, fruits.Length)],
            spawnPos,
            Quaternion.identity
        );

        // ランダムスピードで左に流す
        float speed = Random.Range(minSpeed, maxSpeed);
        Rigidbody2D rb = fruit.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}
