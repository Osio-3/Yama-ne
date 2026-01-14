using UnityEngine;

public class ItemMover : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // ç∂Ç…ó¨ÇÍÇÈ
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
