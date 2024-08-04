using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Простое движение в фиксированном направлении
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
