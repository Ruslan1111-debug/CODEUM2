using UnityEngine;

public class WeakEnemy : MonoBehaviour
{
    public float speed = 10f;
    public int maxHP = 50;
    private int currentHP;
    public float fireRate = 3f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioClip shootSound;

    private float fireCooldown;
    private Transform player;

    void Start()
    {
        currentHP = maxHP;
        fireCooldown = 0f;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void Fire()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            fireCooldown = fireRate;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        var experienceManager = FindObjectOfType<ExperienceManager>();
        if (experienceManager != null)
        {
            experienceManager.AddExperience(10); // Пример XP для WeakEnemy
        }
        Destroy(gameObject);
    }
}
