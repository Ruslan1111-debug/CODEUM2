using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10; // Урон, который наносит пуля

    private Transform player;

    void Start()
    {
        // Найти игрока по тегу
        player = GameObject.FindWithTag("Player").transform;
        if (player != null)
        {
            // Направление пули к игроку
            Vector2 direction = (player.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else
        {
            // Если игрок не найден, удалить пулю
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Наносим урон игроку
            other.GetComponent<HealthPlayer>().TakeDamage(damage);
            Destroy(gameObject); // Уничтожить пулю после попадания
        }
    }
}
