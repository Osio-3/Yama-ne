using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("移動スピード")]
    public float moveSpeed = 5f;

    private Vector2 moveDirection;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力（WASD）
        float x = Input.GetAxisRaw("Horizontal");  // A(-1) D(+1)
        float y = Input.GetAxisRaw("Vertical");    // S(-1) W(+1)

        moveDirection = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        // 実際に動かす
        rb.velocity = moveDirection * moveSpeed;
    }
}
