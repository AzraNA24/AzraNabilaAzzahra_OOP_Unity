using UnityEngine;

public class EnemyBoss : Enemy
{
        private float speed = 2f;
        private Vector2 direction;
    public Bullet bulletPrefab;           // Prefab peluru yang akan ditembakkan
    public Transform bulletSpawnPoint;     // Titik spawn peluru

    private float shootInterval = 0.5f;      // Interval waktu antar tembakan dalam detik
    private float shootTimer = 0f; 
        // Timer untuk melacak waktu tembakan

    protected override void Awake()
    {
        base.Awake();
        transform.position = new Vector2(10f, Random.Range(-2f, 4f)); // Spawn dari kanan
        direction = Vector2.left;
    }

    protected override void Update()
    {
        base.Update();

        // Menembak setiap interval
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f; // Reset timer setelah menembak
        }

        transform.Translate(direction * speed * Time.deltaTime);

        // Jika sudah keluar dari layar, balik arah
        if (transform.position.x <= -10f)
        {
            direction = Vector2.right;
        }
        else if (transform.position.x >= 10f)
        {
            direction = Vector2.left;
        }
    }

private void Shoot()
{
    if (bulletPrefab != null && bulletSpawnPoint != null)
    {
        Debug.Log("EnemyBoss menembak!");
        Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * newBullet.bulletSpeed;
    }
    else
    {
        Debug.LogWarning("Bullet prefab atau bullet spawn point belum diatur pada EnemyBoss.");
    }
}
}
