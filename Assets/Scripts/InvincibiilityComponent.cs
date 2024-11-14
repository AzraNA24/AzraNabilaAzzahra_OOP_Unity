using System.Collections;
using UnityEngine;

public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine blinkRoutine;
    public bool isInvincible = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalMaterial = spriteRenderer.material;
        }
    }

    private IEnumerator BlinkingRoutine()
    {
        isInvincible = true;

        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(blinkInterval);
        }

        isInvincible = false;
    }

    public void StartBlinking()
    {
        if (!isInvincible)
        {
            if (blinkRoutine != null)
            {
                StopCoroutine(blinkRoutine);
            }
            blinkRoutine = StartCoroutine(BlinkingRoutine());
        }
    }
}