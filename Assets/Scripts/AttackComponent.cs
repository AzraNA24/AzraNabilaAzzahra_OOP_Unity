using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                hitbox.Damage(bulletPrefab, gameObject); // Pass source as gameObject
            }
            else
            {
                hitbox.Damage(damage, gameObject); // Pass source as gameObject
            }

            InvincibilityComponent flashComponent = collision.GetComponent<InvincibilityComponent>();
            if (flashComponent != null && !flashComponent.isInvincible)
            {
                flashComponent.StartBlinking();
            }
        }
    }
}
