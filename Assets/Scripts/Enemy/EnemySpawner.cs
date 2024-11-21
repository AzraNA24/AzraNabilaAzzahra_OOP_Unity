using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject spawnedEnemy;
    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 6;
    public int totalKill = 0;
    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;
    public bool isSpawning = false;

    private void Start()
    {
        spawnCount = defaultSpawnCount;
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating(nameof(SpawnEnemies), 0, spawnInterval);
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke(nameof(SpawnEnemies));
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
        }

        combatManager.totalEnemies += spawnCount;

        // Tingkatkan jumlah spawn jika total kill mencukupi
        if (totalKill >= minimumKillsToIncreaseSpawnCount)
        {
            totalKill = 0; // Reset kill count
            spawnCount += spawnCountMultiplier;
        }
    }
}
