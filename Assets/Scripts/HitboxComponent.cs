using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    private InvincibilityComponent flashComponent;

    private void Start()
    {
        flashComponent = GetComponent<InvincibilityComponent>();
    }

    public void Damage(int damage, GameObject source)
    {
        // Only apply damage if source is not an enemy
        if (healthComponent != null && (flashComponent == null || !flashComponent.isInvincible) && !source.CompareTag("Enemy"))
        {
            healthComponent.Subtract(damage);
        }
    }

    public void Damage(Bullet bullet, GameObject source)
    {
        // Only apply damage if source is not an enemy
        if (healthComponent != null && (flashComponent == null || !flashComponent.isInvincible) && !source.CompareTag("Enemy"))
        {
            healthComponent.Subtract(bullet.damage);
        }
    }
}
