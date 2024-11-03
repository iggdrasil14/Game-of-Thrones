using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Скорость перемещения камеры по горизонтали и вертикали
    public float moveSpeed = 10f;
    // Скорость масштабирования камеры
    public float zoomSpeed = 2f;
    // Максимально и минимально допустимый уровень масштаба камеры
    public float minZoom = 5f;
    public float maxZoom = 20f;

    // Границы мира в виде значений по осям
    public Vector2 worldMinBounds;
    public Vector2 worldMaxBounds;

    // Точки, определяющие границы мира (можно задать в редакторе)
    public Transform minBoundsPoint;
    public Transform maxBoundsPoint;

    // Используемые клавиши для управления камерой
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode zoomInKey = KeyCode.Equals; // Клавиша "+"
    public KeyCode zoomOutKey = KeyCode.Minus; // Клавиша "-"

    void Start()
    {
        // Устанавливаем границы мира на основе координат точек
        if (minBoundsPoint != null && maxBoundsPoint != null)
        {
            worldMinBounds = minBoundsPoint.position;
            worldMaxBounds = maxBoundsPoint.position;
        }
    }

    void Update()
    {
        // Обрабатываем перемещение с помощью клавиш A, D, W, S
        HandleKeyboardMovement();

        // Обрабатываем увеличение и уменьшение масштаба с помощью клавиатуры и колесика мыши
        HandleZoom();

        // Ограничиваем позицию камеры границами мира
        ClampCameraPosition();
    }

    // Метод для обработки движения камеры с помощью клавиш A, D, W, S
    void HandleKeyboardMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(moveLeftKey))
        {
            moveDirection.x = -1;
        }
        if (Input.GetKey(moveRightKey))
        {
            moveDirection.x += 1;
        }
        if (Input.GetKey(moveUpKey))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(moveDownKey))
        {
            moveDirection.y -= 1;
        }

        //moveDirection.Normalize();// ось Х - 15 .... 0.15 -- 1
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // Метод для обработки изменения масштаба камеры с помощью колесика мыши и клавиш "+" и "-"
    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            Camera.main.orthographicSize -= scroll * zoomSpeed;
        }

        if (Input.GetKey(zoomInKey))
        {
            Camera.main.orthographicSize -= zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(zoomOutKey))
        {
            Camera.main.orthographicSize += zoomSpeed * Time.deltaTime;
        }

        // Ограничиваем масштаб в заданных пределах
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
    }

    // Метод для ограничения позиции камеры границами мира
    void ClampCameraPosition()
    {
        Vector3 clampedPosition = transform.position;

        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, worldMinBounds.x + cameraWidth, worldMaxBounds.x - cameraWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, worldMinBounds.y, worldMaxBounds.y );

        transform.position = clampedPosition;
    }
}

/*
Описание:
1. Скрипт прикрепляется к камере, чтобы управлять её передвижением и масштабированием.
2. "moveSpeed" и "zoomSpeed" контролируют скорость передвижения и изменения масштаба соответственно.
3. "worldMinBounds" и "worldMaxBounds" определяют границы мира для ограничения передвижения камеры.
4. Границы мира могут быть заданы через точки "minBoundsPoint" и "maxBoundsPoint", которые определяют зону допустимого перемещения камеры.
5. Управление передвижением камеры осуществляется с помощью клавиш A, D, W, S или путём перемещения мыши при зажатой левой кнопке.
6. Масштаб камеры регулируется с помощью колесика мыши или клавиш "+" и "-".
7. Камера автоматически ограничивает свою позицию в пределах границ мира с учётом текущего масштаба.
*/
