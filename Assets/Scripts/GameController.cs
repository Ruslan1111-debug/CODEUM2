// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class GameController : MonoBehaviour
// {
//     public int currentExperience = 0;
//     public float gameDuration = 120f; // Длительность игры в секундах
//     private float timer;
//     public GameObject winPanel; // Панель выигрыша

//     void Start()
//     {
//         timer = gameDuration;
//         winPanel.SetActive(false); // Скрыть панель в начале
//     }

//     void Update()
//     {
//         // Таймер
//         if (timer > 0)
//         {
//             timer -= Time.deltaTime;
//         }
//         else
//         {
//             // Время вышло, вызвать метод окончания игры
//             EndGame(false);
//         }
//     }

//     public void AddExperience(int amount)
//     {
//         currentExperience += amount;
//     }

//     public void EndGame(bool won)
//     {
//         if (won)
//         {
//             winPanel.SetActive(true); // Показать панель выигрыша
//         }
//         Time.timeScale = 0f; // Остановить игру
//     }

//     public void FinishLevel()
//     {
//         // Сохраняет текущий ранг
//         PlayerPrefs.SetInt("currentRank", CalculateRank());
        
//         // Загружает следующую сцену
//         int nextSceneIndex = GetNextSceneIndex();
//         SceneManager.LoadScene(nextSceneIndex);
//     }

//     int CalculateRank()
//     {
//         // Логика расчета ранга на основе текущего опыта
//         // Например, если каждые 100 опыта - новый ранг
//         return currentExperience / 100;
//     }

//     int GetNextSceneIndex()
//     {
//         // Пример логики для выбора следующей сцены
//         return SceneManager.GetActiveScene().buildIndex + 1; // Переход к следующей сцене
//     }
// }
