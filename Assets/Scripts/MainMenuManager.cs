using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text rankText; // UI элемент для отображения ранга
    public Text xpText;   // UI элемент для отображения опыта

    void Start()
    {
        // Загрузка ранга и опыта из PlayerPrefs
        int currentRank = PlayerPrefs.GetInt("currentRank", 0);
        int currentXP = PlayerPrefs.GetInt("currentXP", 0);

        // Обновление UI
        if (rankText != null)
        {
            rankText.text = "Rank: " + currentRank;
        }

        if (xpText != null)
        {
            xpText.text = "XP: " + currentXP;
        }
    }
}
