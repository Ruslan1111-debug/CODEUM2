using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject smallAsteroidPrefab;
    public GameObject largeAsteroidPrefab;
    public float spawnInterval = 30f;
    public float spawnHeight = 10f; // Высота спавна над игроком
    public float horizontalRange = 10f; // Горизонтальный диапазон спавна

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnAsteroid();
            timer = spawnInterval;
        }
    }

    void SpawnAsteroid()
    {
        // Найти игрока
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Выбрать случайную позицию по горизонтали вокруг игрока
            Vector3 spawnPosition = new Vector3(
                player.transform.position.x + Random.Range(-horizontalRange, horizontalRange),
                player.transform.position.y + spawnHeight,
                0
            );

            GameObject asteroidPrefab = (Random.value > 0.5f) ? smallAsteroidPrefab : largeAsteroidPrefab;
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
