using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject weakEnemyPrefab;
    public GameObject strongEnemyPrefab;
    public float weakEnemySpawnInterval = 5f;
    public float strongEnemySpawnInterval = 10f;

    public Vector2 spawnAreaMin; // Минимальные координаты области спауна
    public Vector2 spawnAreaMax; // Максимальные координаты области спауна

    private float weakEnemySpawnTimer;
    private float strongEnemySpawnTimer;

    void Start()
    {
        weakEnemySpawnTimer = 0f;
        strongEnemySpawnTimer = 0f;
    }

    void Update()
    {
        weakEnemySpawnTimer += Time.deltaTime;
        strongEnemySpawnTimer += Time.deltaTime;

        if (weakEnemySpawnTimer >= weakEnemySpawnInterval)
        {
            SpawnWeakEnemy();
            weakEnemySpawnTimer = 0f;
        }

        if (strongEnemySpawnTimer >= strongEnemySpawnInterval)
        {
            SpawnStrongEnemy();
            strongEnemySpawnTimer = 0f;
        }
    }

    void SpawnWeakEnemy()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        Instantiate(weakEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnStrongEnemy()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        Instantiate(strongEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector2 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        return new Vector2(randomX, randomY);
    }
}
