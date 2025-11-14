using UnityEngine;

public class PrefabSwitcherAlwaysHalf : MonoBehaviour
{
    [Header("通常プレハブ")]
    public GameObject normalPrefab;

    [Header("切り替えプレハブ")]
    public GameObject changedPrefab;

    private GameObject currentInstance;
    private bool isChanged = false;

    void Start()
    {
        // 最初のプレハブを生成
        SpawnPrefab(normalPrefab);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 既存のプレハブ削除
            if (currentInstance != null)
            {
                Destroy(currentInstance);
            }

            // 切り替え
            isChanged = !isChanged;
            GameObject prefabToSpawn = isChanged ? changedPrefab : normalPrefab;

            // 新しいプレハブを生成
            SpawnPrefab(prefabToSpawn);
        }
    }

    void SpawnPrefab(GameObject prefab)
    {
        if (prefab == null) return;

        // このオブジェクトの位置に生成
        currentInstance = Instantiate(prefab, transform.position, Quaternion.identity);

        // スケールを常に0.5に固定
        currentInstance.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        // 親をこのオブジェクトにする（位置を合わせやすくする）
        currentInstance.transform.SetParent(transform);
    }
}
