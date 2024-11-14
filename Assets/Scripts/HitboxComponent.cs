using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    private InvincibilityComponent invincibilityComponent;

    private void Start()
    {
        invincibilityComponent = GetComponent<InvincibilityComponent>();
    }

    public void Damage(int damage)
    {
        if (healthComponent != null && (invincibilityComponent == null || !invincibilityComponent.isInvincible))
        {
            healthComponent.Subtract(damage);
            invincibilityComponent?.StartBlinking(); // Start blinking after taking damage
        }
    }

    public void Damage(Bullet bullet)
    {
        if (healthComponent != null && (invincibilityComponent == null || !invincibilityComponent.isInvincible))
        {
            healthComponent.Subtract(bullet.damage);
            invincibilityComponent?.StartBlinking(); // Start blinking after taking damage
        }
    }
}
