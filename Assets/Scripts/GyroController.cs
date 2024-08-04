using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{
    private Gyroscope gyro;
    private Quaternion baseRotation;

    public float rotationSpeed = 1.0f;
    public float gyroSensitivity = 2.0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 10f;

    public AudioClip shootSound;
    private AudioSource audioSource;

    public Button shootButton;
    public Button leftButton;
    public Button rightButton;

    private bool moveLeft = false;
    private bool moveRight = false;

    public float minX = -10f;
    public float maxX = 10f;

    public Slider sensitivitySlider;
    public Text sensitivityText;

    void Start()
    {
        // Initialize Gyroscope
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            baseRotation = Quaternion.Euler(90f, 0f, 0f); // Adjust base rotation for proper alignment
        }
        else
        {
            Debug.LogError("Gyroscope not supported on this device.");
        }

        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // Initialize Buttons
        if (shootButton != null)
        {
            shootButton.onClick.AddListener(Shoot);
        }
        else
        {
            Debug.LogError("Shoot button not assigned.");
        }

        if (leftButton != null && rightButton != null)
        {
            // Register button listeners for down and up events
            var leftButtonEvents = leftButton.gameObject.AddComponent<ButtonEvent>();
            leftButtonEvents.onPointerDown += () => MoveLeft(true);
            leftButtonEvents.onPointerUp += () => MoveLeft(false);

            var rightButtonEvents = rightButton.gameObject.AddComponent<ButtonEvent>();
            rightButtonEvents.onPointerDown += () => MoveRight(true);
            rightButtonEvents.onPointerUp += () => MoveRight(false);
        }
        else
        {
            Debug.LogError("Movement buttons not assigned.");
        }

        // Initialize Slider
        if (sensitivitySlider != null)
        {
            sensitivitySlider.minValue = 2f;
            sensitivitySlider.maxValue = 60f;
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
            UpdateSensitivity(sensitivitySlider.value); // Set initial value
        }
        else
        {
            Debug.LogError("Sensitivity Slider not assigned.");
        }
        
        if (sensitivityText != null)
        {
            sensitivityText.text = "Sensitivity: " + gyroSensitivity.ToString("F1");
        }
    }

    void Update()
    {
        if (gyro != null)
        {
            // Get gyroscope input and apply sensitivity
            Quaternion gyroRotation = gyro.attitude * baseRotation;
            float zRotation = -gyroRotation.eulerAngles.y * gyroSensitivity;
            transform.rotation = Quaternion.Euler(0, 0, zRotation);

            // Movement handling
            if (moveLeft)
            {
                transform.position += Vector3.left * rotationSpeed * Time.deltaTime;
            }
            if (moveRight)
            {
                transform.position += Vector3.right * rotationSpeed * Time.deltaTime;
            }

            // Clamp position
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }

            if (shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
        else
        {
            Debug.LogError("Bullet prefab or fire point not assigned.");
        }
    }

    private void MoveLeft(bool isPressed)
    {
        moveLeft = isPressed;
    }

    private void MoveRight(bool isPressed)
    {
        moveRight = isPressed;
    }

    private void UpdateSensitivity(float value)
    {
        gyroSensitivity = value;
        if (sensitivityText != null)
        {
            sensitivityText.text = "Sensitivity: " + gyroSensitivity.ToString("F1");
        }
    }

    private void OnDestroy()
    {
        if (gyro != null)
        {
            gyro.enabled = false;
        }
    }
}
