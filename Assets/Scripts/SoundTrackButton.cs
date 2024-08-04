using UnityEngine;
using UnityEngine.UI;

public class SoundTrackButton : MonoBehaviour
{
    public Button muteButton;
    public Sprite musicOnSprite;  // Спрайт для включенной музыки
    public Sprite musicOffSprite; // Спрайт для выключенной музыки
    private Image buttonImage;

    void Start()
    {
        buttonImage = muteButton.GetComponent<Image>();

        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMusic);
        }

        // Установить начальный спрайт в зависимости от состояния музыки
        BackgroundMusic music = FindObjectOfType<BackgroundMusic>();
        if (music != null && buttonImage != null)
        {
            buttonImage.sprite = music.IsMuted() ? musicOffSprite : musicOnSprite;
        }
    }

    void ToggleMusic()
    {
        // Найти экземпляр BackgroundMusic и переключить состояние
        BackgroundMusic music = FindObjectOfType<BackgroundMusic>();
        if (music != null)
        {
            music.ToggleMute();

            // Изменить спрайт кнопки в зависимости от состояния музыки
            if (buttonImage != null)
            {
                buttonImage.sprite = music.IsMuted() ? musicOffSprite : musicOnSprite;
            }
        }
    }
}
