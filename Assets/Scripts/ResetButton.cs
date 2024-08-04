using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetButton : MonoBehaviour
{
    private Rewarded rewardedAd;

    private void Start()
    {
        rewardedAd = FindObjectOfType<Rewarded>();
    }

    public void Restart()
    {
        rewardedAd.ShowRewardedAd(() =>
        {
            StartCoroutine(RestartCoroutine());
        });
    }

    private IEnumerator RestartCoroutine()
    {
        // Даем время, чтобы всё освободилось
        yield return null;

        // Получаем текущую активную сцену
        Scene currentScene = SceneManager.GetActiveScene();

        // Загружаем ту же сцену заново
        SceneManager.LoadScene(currentScene.name);
    }
}
