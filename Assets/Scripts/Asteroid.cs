using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int hitsToDestroy = 3; // Количество попаданий для уничтожения
    private int currentHits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            currentHits++;
            Destroy(other.gameObject); // Уничтожение снаряда

            if (currentHits >= hitsToDestroy)
            {
                Destroy(gameObject); // Уничтожение астероида
            }
        }
    }
}
