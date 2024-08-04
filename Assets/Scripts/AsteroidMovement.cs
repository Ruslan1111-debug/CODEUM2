using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public string playerTag = "Player"; // Тег игрока для поиска
    public float moveSpeed = 1f; // Скорость движения к игроку
    public float rotationSpeed = 10f; // Скорость вращения

    private Transform playerTransform;

    void Start()
    {
        // Поиск игрока по тегу при старте
        GameObject player = GameObject.FindWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // Проверка на наличие ссылки на игрока
        if (playerTransform != null)
        {
            // Перемещение астероида к позиции игрока
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }

        // Вращение астероида
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
