using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankDisplay : MonoBehaviour
{
    public Image rankImage;
    public Sprite[] rankSprites;
    public Slider experienceSlider;
    public TextMeshProUGUI experienceText;
    private ExperienceManager experienceManager;

    void Start()
    {
        experienceManager = FindObjectOfType<ExperienceManager>();
        if (experienceManager == null)
        {
            Debug.LogError("ExperienceManager not found in the scene.");
            return;
        }
        UpdateRankDisplay();
        UpdateExperienceUI();
    }

    void Update()
    {
        // Обновляем отображение ранга и опыта на каждом кадре
        UpdateRankDisplay();
        UpdateExperienceUI();
    }

    void UpdateRankDisplay()
    {
        if (experienceManager != null)
        {
            int currentRank = experienceManager.currentRank;
            if (currentRank >= 0 && currentRank < rankSprites.Length)
            {
                rankImage.sprite = rankSprites[currentRank];
            }
        }
    }

    void UpdateExperienceUI()
    {
        if (experienceManager != null)
        {
            // Обновляем слайдер опыта
            if (experienceSlider != null)
            {
                experienceSlider.minValue = 0;
                experienceSlider.maxValue = experienceManager.experienceForNextRank[experienceManager.currentRank];
                experienceSlider.value = experienceManager.currentExperience;
            }

            // Обновляем текст опыта
            if (experienceText != null)
            {
                int experienceToNextRank = experienceManager.GetExperienceToNextRank();
                experienceText.text = $"{experienceManager.currentExperience}/{experienceManager.experienceForNextRank[experienceManager.currentRank]} XP";
            }
        }
    }
}
