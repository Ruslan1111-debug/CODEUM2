using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private bool soundEnabled = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект между сценами
        }
        else
        {
            Destroy(gameObject); // Удаляем дубликаты
        }
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;
        // Передайте состояние звука другим объектам, если необходимо
    }

    public bool IsSoundEnabled()
    {
        return soundEnabled;
    }
}
