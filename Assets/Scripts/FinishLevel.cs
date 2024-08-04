using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public int requiredRankForNextLevel = 0;
    private ExperienceManager experienceManager;

    private static FinishLevel instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        experienceManager = FindObjectOfType<ExperienceManager>();

        // Проверяем ранг и загружаем следующий уровень, если ранг достаточен
        if (experienceManager != null && experienceManager.currentRank >= requiredRankForNextLevel)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("currentScene", nextSceneIndex);
        PlayerPrefs.Save(); // Сохраняем изменения
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save(); // Сохраняем изменения после очистки
    }
}
