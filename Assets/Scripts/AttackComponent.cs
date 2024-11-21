using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
{
    HitboxComponent hitbox = collision.GetComponent<HitboxComponent>();

    if (hitbox != null)
    {
        if (bulletPrefab != null)
        {
            hitbox.Damage(bulletPrefab);
        }
        else
        {
            hitbox.Damage(damage);
        }

        InvincibilityComponent flashComponent = collision.GetComponent<InvincibilityComponent>();
        if (flashComponent != null && !flashComponent.isInvincible)
        {
            flashComponent.StartBlinking();
        }
    }
}

}
