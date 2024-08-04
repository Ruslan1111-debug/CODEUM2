using UnityEngine;
using TMPro;

public class HealthPlayer : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject gameOverPanel; // Панель с результатами

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        gameOverPanel.SetActive(false); // Убедитесь, что панель не видна в начале
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.text = "HP: " + currentHealth.ToString();
    }

    void Die()
    {
        // Остановить игру
        Time.timeScale = 0f;

        // Показать панель с результатами
        gameOverPanel.SetActive(true);
    }
}
