using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    private void Start()
    {
        StartNextWave();
    }

    private void Update()
    {
        // Hitung mundur untuk memulai wave berikutnya
        timer += Time.deltaTime;

        if (timer >= waveInterval && totalEnemies <= 0)
        {
            timer = 0;
            waveNumber++;
            StartNextWave();
        }
    }

    private void StartNextWave()
    {
        foreach (var spawner in enemySpawners)
        {
            spawner.defaultSpawnCount = waveNumber; // Meningkatkan musuh berdasarkan wave
            spawner.StartSpawning();
        }
    }

    public void EnemyKilled()
    {
        totalEnemies--;
        if (totalEnemies <= 0)
        {
            // Semua musuh di wave ini sudah mati, hentikan spawn
            foreach (var spawner in enemySpawners)
            {
                spawner.StopSpawning();
            }
        }
    }
}
