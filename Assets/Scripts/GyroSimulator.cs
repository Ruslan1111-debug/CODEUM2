// using UnityEngine;
// using UnityEngine.UI;

// public class GyroSimulator : MonoBehaviour
// {
//     public Text gyroOutputText;
//     public float sensitivity = 5.0f;

//     private Vector3 simulatedGyroRotation;

//     void Update()
//     {
//         float horizontal = Input.GetAxis("Horizontal"); // Влево/вправо
//         float vertical = Input.GetAxis("Vertical"); // Вверх/вниз

//         simulatedGyroRotation = new Vector3(-vertical, horizontal, 0) * sensitivity;

//         // Вывод данных гироскопа в лог
//         Debug.Log($"Simulated Gyro Rotation: {simulatedGyroRotation}");

//         if (gyroOutputText != null)
//         {
//             gyroOutputText.text = $"Simulated Gyro Rotation: {simulatedGyroRotation}";
//         }
//     }

//     public Vector3 GetSimulatedGyroRotation()
//     {
//         return simulatedGyroRotation;
//     }
// }
