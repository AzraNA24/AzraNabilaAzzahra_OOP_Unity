using UnityEngine;

public class EnemyBoss : Enemy
{
        private float speed = 2f;
        private Vector2 direction;
    public Bullet bulletPrefab;      
    public Transform bulletSpawnPoint;

    private float shootInterval = 0.5f;
    private float shootTimer = 0f; 

    protected override void Awake()
    {
        base.Awake();
        transform.position = new Vector2(10f, Random.Range(-2f, 4f));
        direction = Vector2.left;
    }

    protected override void Update()
    {
        base.Update();

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }

        transform.Translate(direction * speed * Time.deltaTime);
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
