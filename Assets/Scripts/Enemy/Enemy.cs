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

        rb.gravityScale = 0;
    }

    public void LookAtPlayer(Vector3 playerPosition)
    {
        Vector3 direction = (playerPosition - transform.position).normalized;
        transform.up = -direction;
    }

    protected virtual void Update()
    {
    }
}
