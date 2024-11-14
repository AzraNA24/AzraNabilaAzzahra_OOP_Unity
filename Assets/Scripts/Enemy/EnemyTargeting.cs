using UnityEngine;

public class EnemyTargeting : Enemy
{
    private Transform player;
    private float speed = 5f;

    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Update()
    {
        base.Update();
        if (player != null)
        {
            // Gerak menuju ke posisi Player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            // Menghadap ke arah Player
            transform.up = -direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
