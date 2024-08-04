// using UnityEngine;

// public class PlayerShooting : MonoBehaviour
// {
//     public GameObject bulletPrefab; // Префаб снаряда
//     public Transform firePoint; // Точка, откуда вылетает снаряд
//     public float bulletSpeed = 10f; // Скорость снаряда
//     public float gyroSensitivity = 1.0f; // Чувствительность гироскопа

//     private bool canShoot = true; // Флаг для контроля стрельбы

//     void Start()
//     {
//         // Активировать гироскоп
//         Input.gyro.enabled = true;
//     }

//     void Update()
//     {
//         // Управление с помощью гироскопа
//         transform.Rotate(0, 0, -Input.gyro.rotationRate.x * gyroSensitivity);

//         // Стрельба
//         if ((Input.touchCount > 0 || Input.GetMouseButtonDown(0)) && canShoot)
//         {
//             Shoot();
//             canShoot = false; // Предотвращаем повторные выстрелы
//         }
//         else if (Input.touchCount == 0 && !Input.GetMouseButton(0))
//         {
//             canShoot = true; // Разрешаем стрельбу снова
//         }
//     }

//     void Shoot()
//     {
//         // Создание и запуск снаряда
//         GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//         Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
//         rb.velocity = firePoint.up * bulletSpeed;
//     }
// }
