using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120f; // 2 минуты
    public Text timerText;
    public GameObject winPanel;

    void Start()
    {
        winPanel.SetActive(false); // Скрыть панель победы при запуске
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            Win();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Win()
    {
        winPanel.SetActive(true); // Отображение панели победы
        Time.timeScale = 0; // Остановка времени в игре
    }
}
