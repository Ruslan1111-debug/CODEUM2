using UnityEngine;
using UnityEngine.UI;

public class GyroTest : MonoBehaviour
{
    public Text gyroOutputText;  // Текстовое поле для вывода данных гироскопа

    void Start()
    {
        Input.gyro.enabled = true;  // Включаем гироскоп
    }

    void Update()
    {
        // Получаем данные гироскопа
        Vector3 gyroRotation = Input.gyro.rotationRateUnbiased;

        // Отображаем данные гироскопа на экране
        if (gyroOutputText != null)
        {
            gyroOutputText.text = $"Gyro Rotation: {gyroRotation}";
        }
    }
}
