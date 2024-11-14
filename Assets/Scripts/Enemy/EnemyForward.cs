using UnityEngine;

public class EnemyForward : Enemy
{
    private float speed = 5f;
    private Vector2 direction;

    protected override void Awake()
    {
        base.Awake();
        // Spawn dari atas dengan arah ke bawah
        transform.position = new Vector2(Random.Range(-8f, 8f), 10f);
        direction = Vector2.down;
    }

    protected override void Update()
    {
        base.Update();
        // Gerakkan Enemy ke arah yang ditentukan
        transform.Translate(direction * speed * Time.deltaTime);

        // Balik arah ketika mencapai batas atas atau bawah layar
        if (transform.position.y <= -10f)
        {
            direction = Vector2.up;
        }
        else if (transform.position.y >= 10f)
        {
            direction = Vector2.down;
        }
    }
}
