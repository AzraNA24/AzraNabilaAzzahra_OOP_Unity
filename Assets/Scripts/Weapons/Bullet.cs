using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Pastikan bullet bergerak ke arah yang benar (misalnya, ke atas)
        rb.velocity = transform.up * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false); // Kembalikan Bullet ke Object Pool jika bertabrakan
    }
}
