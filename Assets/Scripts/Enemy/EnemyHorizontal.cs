using UnityEngine;

public class EnemyHorizontal : Enemy
{
    private Vector2 direction;
    private float speed = 5f;

    protected override void Awake()
    {
        base.Awake();
        // Tentukan apakah akan spawn dari kiri atau kanan
        if (Random.value > 0.5f)
        {
            transform.position = new Vector2(-10f, Random.Range(-5f, 5f)); // Spawn dari kiri
            direction = Vector2.right;
        }
        else
        {
            transform.position = new Vector2(10f, Random.Range(-5f, 5f)); // Spawn dari kanan
            direction = Vector2.left;
        }
    }

    protected override void Update()
    {
        base.Update();
        // Gerakkan Enemy ke arah yang sudah ditentukan
        transform.Translate(direction * speed * Time.deltaTime);

        // Jika sudah keluar dari layar, balik arah
        if (transform.position.x > 12f || transform.position.x < -12f)
        {
            direction = -direction;
        }
    }
}
