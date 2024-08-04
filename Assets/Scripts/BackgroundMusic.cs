using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance = null;
    private AudioSource audioSource;
    private bool isMuted = false;

    void Awake()
    {
        // Проверяем, существует ли уже экземпляр BackgroundMusic
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожать этот объект при загрузке новой сцены
            audioSource = GetComponent<AudioSource>();
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Уничтожить дубликат
        }
    }

    // Метод для переключения звука
    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
    }

    // Метод для получения текущего состояния звука
    public bool IsMuted()
    {
        return isMuted;
    }
}
