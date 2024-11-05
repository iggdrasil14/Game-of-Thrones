using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float moveSpeed = 10f;               // �������� ����������� ������ �� ����������� � ���������.
    public float zoomSpeed = 2f;                //�������� ��������������� ������.
    public float minZoom = 5f;                  // ����������� ������� �������� ������.
    public float maxZoom = 20f;                 // ������������ ������� �������� ������.
    public Vector2 worldMinBounds;              // ����������� ������� ���� �� ���� X � Y.
    public Vector2 worldMaxBounds;              // ������������ ������� ���� �� ���� X � Y.

    void LateUpdate()
    {
        HandleMovement();
        HandleZoom();
        ClampCameraPosition();
    }

    /// <summary>
    /// ������������ ����������� ������ �� ����������� � ��������� � ������� ������.
    /// </summary>
    void HandleMovement()
    {
        // �������� ����������� �������� �� ������ ����� ������������
        Vector3 moveDirection = new Vector3(
            Input.GetAxisRaw("Horizontal"),     // �������������� ����������� (A/D ��� �������)
            Input.GetAxisRaw("Vertical"),       // ������������ ����������� (W/S ��� �������)
            0
        ).normalized;

        // ��������� ������� ������ � ������ �������� � �������
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// ������������ ��������� �������� ������ � ������� �������� ���� � ������ "+" � "-".
    /// </summary>
    void HandleZoom()
    {
        // �������� ��������� �������� �� ������ ����� ������������
        float zoomChange = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoomChange += (Input.GetKey(KeyCode.Equals) ? -zoomSpeed : 0) * Time.deltaTime;
        zoomChange += (Input.GetKey(KeyCode.Minus) ? zoomSpeed : 0) * Time.deltaTime;

        // ������������ ������� �������� � �������� ��������
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + zoomChange, minZoom, maxZoom);
    }

    /// <summary>
    /// ������������ ������� ������ � �������� �������� ������ ����.
    /// </summary>
    void ClampCameraPosition()
    {
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // ������������ ��������� ������, ����� ��� �� �������� �� ������� ����
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, worldMinBounds.x + cameraWidth, worldMaxBounds.x - cameraWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, worldMinBounds.y + cameraHeight, worldMaxBounds.y - cameraHeight);

        transform.position = clampedPosition;
    }
}
