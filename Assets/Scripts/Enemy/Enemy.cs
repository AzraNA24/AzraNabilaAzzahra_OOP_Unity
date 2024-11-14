using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int level = 1;

    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set Rigidbody2D agar terpengaruh Physics tetapi tanpa Gravity
        rb.gravityScale = 0;
    }

    // Metode ini bisa dipanggil ketika Enemy spawn di posisi yang berhadapan dengan Player
    public void LookAtPlayer(Vector3 playerPosition)
    {
        Vector3 direction = (playerPosition - transform.position).normalized;
        transform.up = -direction;  // Menghadap ke bawah (arah -up)
    }

    protected virtual void Update()
    {
        // Base behavior untuk Enemy
    }
}
