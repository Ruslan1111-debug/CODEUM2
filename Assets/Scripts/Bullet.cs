using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Урон, наносимый пулей

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Проверяем, с каким типом врага столкнулась пуля и наносим урон
            WeakEnemy weakEnemy = collision.GetComponent<WeakEnemy>();
            StrongEnemy strongEnemy = collision.GetComponent<StrongEnemy>();

            if (weakEnemy != null)
            {
                weakEnemy.TakeDamage(damage);
            }
            else if (strongEnemy != null)
            {
                strongEnemy.TakeDamage(damage);
            }

            // Уничтожаем пулю после столкновения
            Destroy(gameObject);
        }
    }
}
