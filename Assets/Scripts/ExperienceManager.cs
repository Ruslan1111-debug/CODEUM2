using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public int currentExperience = 0;
    public int currentRank = 0;
    public int[] experienceForNextRank;

    private const string ExperienceKey = "Experience";
    private const string RankKey = "Rank";

    void Awake()
    {
        // Обеспечивает, чтобы объект не удалялся при смене сцен
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        LoadExperience();
        UpdateRank();
    }

    public void AddExperience(int amount)
    {
        currentExperience += amount;
        UpdateRank();
        SaveExperience();
    }

    void UpdateRank()
    {
        for (int i = 0; i < experienceForNextRank.Length; i++)
        {
            if (currentExperience < experienceForNextRank[i])
            {
                currentRank = i;
                return;
            }
        }
        currentRank = experienceForNextRank.Length - 1; // Устанавливаем ранг на последний, если опыт превышает все значения
    }

    public int GetExperienceToNextRank()
    {
        if (currentRank < experienceForNextRank.Length)
        {
            return experienceForNextRank[currentRank] - currentExperience;
        }
        return 0; // Нет рангов выше текущего
    }

    void SaveExperience()
    {
        PlayerPrefs.SetInt(ExperienceKey, currentExperience);
        PlayerPrefs.SetInt(RankKey, currentRank);
        PlayerPrefs.Save(); // Сохраняем изменения
    }

    void LoadExperience()
    {
        currentExperience = PlayerPrefs.GetInt(ExperienceKey, 0);
        currentRank = PlayerPrefs.GetInt(RankKey, 0);
    }
}
