using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �������� ����������� ������ �� ����������� � ���������
    public float moveSpeed = 10f;
    // �������� ��������������� ������
    public float zoomSpeed = 2f;
    // ����������� � ���������� ���������� ������� �������� ������
    public float minZoom = 5f;
    public float maxZoom = 20f;

    // ������� ���� � ���� �������� �� ����
    public Vector2 worldMinBounds;
    public Vector2 worldMaxBounds;

    // �����, ������������ ������� ���� (����� ������ � ���������)
    public Transform minBoundsPoint;
    public Transform maxBoundsPoint;

    // ������������ ������� ��� ���������� �������
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode zoomInKey = KeyCode.Equals; // ������� "+"
    public KeyCode zoomOutKey = KeyCode.Minus; // ������� "-"

    void Start()
    {
        // ������������� ������� ���� �� ������ ��������� �����
        if (minBoundsPoint != null && maxBoundsPoint != null)
        {
            worldMinBounds = minBoundsPoint.position;
            worldMaxBounds = maxBoundsPoint.position;
        }
    }

    void Update()
    {
        // ������������ ����������� � ������� ������ A, D, W, S
        HandleKeyboardMovement();

        // ������������ ���������� � ���������� �������� � ������� ���������� � �������� ����
        HandleZoom();

        // ������������ ������� ������ ��������� ����
        ClampCameraPosition();
    }

    // ����� ��� ��������� �������� ������ � ������� ������ A, D, W, S
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

        //moveDirection.Normalize();// ��� � - 15 .... 0.15 -- 1
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // ����� ��� ��������� ��������� �������� ������ � ������� �������� ���� � ������ "+" � "-"
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

        // ������������ ������� � �������� ��������
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
    }

    // ����� ��� ����������� ������� ������ ��������� ����
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
��������:
1. ������ ������������� � ������, ����� ��������� � ������������� � ����������������.
2. "moveSpeed" � "zoomSpeed" ������������ �������� ������������ � ��������� �������� ��������������.
3. "worldMinBounds" � "worldMaxBounds" ���������� ������� ���� ��� ����������� ������������ ������.
4. ������� ���� ����� ���� ������ ����� ����� "minBoundsPoint" � "maxBoundsPoint", ������� ���������� ���� ����������� ����������� ������.
5. ���������� ������������� ������ �������������� � ������� ������ A, D, W, S ��� ���� ����������� ���� ��� ������� ����� ������.
6. ������� ������ ������������ � ������� �������� ���� ��� ������ "+" � "-".
7. ������ ������������� ������������ ���� ������� � �������� ������ ���� � ������ �������� ��������.
*/
