using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Text mapName;
    [SerializeField] private Text mapDescription;
    [SerializeField] private Image mapImage;
    [SerializeField] private Button playButton;
    [SerializeField] private Text lockedText; // Новый текстовый элемент для отображения "Locked"

    public void DisplayMap(Map map)
    {
        if (map == null)
        {
            Debug.LogError("Map is null!");
            return;
        }

        // Отображаем название карты
        mapName.text = map.mapName ?? "No Name";

        // Описание карты, если оно есть
        // mapDescription.text = map.mapDescription ?? "No Description";

        // Проверяем наличие изображения карты
        if (map.mapImage != null)
        {
            mapImage.sprite = map.mapImage;
        }
        else
        {
            Debug.LogWarning("Map image is missing!");
        }

        // Проверка, разблокирована ли карта
        bool mapUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= map.mapIndex;

        // Отображаем или скрываем текст "Locked"
        lockedText.gameObject.SetActive(!mapUnlocked);
        lockedText.text = "LOCKED";

        // Делаем кнопку активной или неактивной
        playButton.interactable = mapUnlocked;

        // Изменяем цвет изображения карты в зависимости от разблокировки
        mapImage.color = mapUnlocked ? Color.white : Color.grey;

        // Удаление всех предыдущих слушателей и добавление нового
        playButton.onClick.RemoveAllListeners();

        if (mapUnlocked && !string.IsNullOrEmpty(map.sceneToLoad.name))
        {
            playButton.onClick.AddListener(() =>
            {
                Debug.Log("Loading scene: " + map.sceneToLoad.name);
                SceneManager.LoadScene(map.sceneToLoad.name);
            });
        }
        else
        {
            Debug.LogWarning("Map is locked or scene name is empty!");
        }
    }
}
