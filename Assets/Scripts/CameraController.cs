using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float moveSpeed = 10f;               // Скорость перемещения камеры по горизонтали и вертикали.
    public float zoomSpeed = 2f;                //Скорость масштабирования камеры.
    public float minZoom = 5f;                  // Минимальный уровень масштаба камеры.
    public float maxZoom = 20f;                 // Максимальный уровень масштаба камеры.
    public Vector2 worldMinBounds;              // Минимальные границы мира по осям X и Y.
    public Vector2 worldMaxBounds;              // Максимальные границы мира по осям X и Y.

    void LateUpdate()
    {
        HandleMovement();
        HandleZoom();
        ClampCameraPosition();
    }

    /// <summary>
    /// Обрабатывает перемещение камеры по горизонтали и вертикали с помощью клавиш.
    /// </summary>
    void HandleMovement()
    {
        // Получаем направление движения на основе ввода пользователя
        Vector3 moveDirection = new Vector3(
            Input.GetAxisRaw("Horizontal"),     // Горизонтальное перемещение (A/D или стрелки)
            Input.GetAxisRaw("Vertical"),       // Вертикальное перемещение (W/S или стрелки)
            0
        ).normalized;

        // Обновляем позицию камеры с учетом скорости и времени
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Обрабатывает изменение масштаба камеры с помощью колесика мыши и клавиш "+" и "-".
    /// </summary>
    void HandleZoom()
    {
        // Получаем изменение масштаба на основе ввода пользователя
        float zoomChange = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoomChange += (Input.GetKey(KeyCode.Equals) ? -zoomSpeed : 0) * Time.deltaTime;
        zoomChange += (Input.GetKey(KeyCode.Minus) ? zoomSpeed : 0) * Time.deltaTime;

        // Ограничиваем уровень масштаба в заданных пределах
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + zoomChange, minZoom, maxZoom);
    }

    /// <summary>
    /// Ограничивает позицию камеры в пределах заданных границ мира.
    /// </summary>
    void ClampCameraPosition()
    {
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Ограничиваем положение камеры, чтобы она не выходила за границы мира
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, worldMinBounds.x + cameraWidth, worldMaxBounds.x - cameraWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, worldMinBounds.y + cameraHeight, worldMaxBounds.y - cameraHeight);

        transform.position = clampedPosition;
    }
}
