using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed = 10;

    void Update()
    {
        // Собираем направление движения
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W))
            moveDirection += Vector3.forward;
        if (Input.GetKeyDown(KeyCode.S))
            moveDirection += Vector3.back;
        if (Input.GetKeyDown(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKeyDown(KeyCode.D))
            moveDirection += Vector3.right;

        // Нормализация для равномерной скорости
        if (moveDirection.magnitude > 1f)
            moveDirection.Normalize();

        // Поворот в направлении движения
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        // Перемещение с учетом скорости и времени
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
