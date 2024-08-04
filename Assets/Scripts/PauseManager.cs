using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами
using UnityEngine.SceneManagement; // Для работы с загрузкой сцен

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // Панель паузы
    public Button resumeButton;    // Кнопка продолжения
    public Button pauseButton;     // Кнопка паузы
    public Button mainMenuButton;  // Кнопка главного меню

    private bool isPaused = false;

    void Start()
    {
        // Убедитесь, что панель паузы изначально скрыта
        pausePanel.SetActive(false);

        // Добавьте обработчики для кнопок
        resumeButton.onClick.AddListener(ResumeGame);
        pauseButton.onClick.AddListener(PauseGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void PauseGame()
    {
        // Останавливаем игру и показываем панель паузы
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Возобновляем игру и скрываем панель паузы
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        // Возобновляем игру и загружаем главную сцену
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
