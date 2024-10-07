using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Land FromLand { get; set; } // Земля, с которой начинается перемещение юнита
    public Collider2D collider2D; // Коллайдер юнита для определения столкновений
    public bool isCanMove; // Флаг, определяющий, может ли юнит двигаться
    public bool isDraged; // Флаг, показывающий, перетаскивается ли юнит игроком
    public int power; // Сила юнита (например, для использования в боевых механиках)
    private Vector3 startPoint; // Точка, в которой началось перемещение юнита

    public GameObject greenCirclePrefab; // Префаб зелёного кружочка для доступного перемещения
    public GameObject redCirclePrefab; // Префаб красного кружочка для недоступного перемещения
    private GameObject currentIndicator; // Текущий индикатор, отображаемый рядом с юнитом

    public void Update()
    {
        if (isDraged)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Получаем текущую позицию мыши в мировых координатах
            transform.position = mousePosition; // Перемещаем юнит к позиции мыши

            // Обновляем индикатор рядом с юнитом в зависимости от возможности перемещения
            if (Land.CurrentLand != null)
            {
                UpdateMoveIndicator(Land.CurrentLand);
            }
        }
    }

    /// <summary>
    /// Метод завершает перемещение юнита. Проверяет, можно ли переместиться на текущую землю.
    /// Если нельзя, юнит возвращается в исходную позицию.
    /// </summary>
    public void MoveComplete()
    {
        if (Land.CurrentLand != null) // Проверяем, выбрана ли новая земля
        {
            if (FromLand.CheckBorderLand(Land.CurrentLand)) // Проверяем, граничит ли новая земля с текущей
            {
                FromLand.RemoveUnit(this); // Убираем юнит с текущей земли
                isCanMove = false; // Запрещаем дальнейшее движение
                isDraged = false; // Прекращаем перетаскивание
                FromLand = Land.CurrentLand; // Обновляем текущую землю юнита
                FromLand.AddUnit(this); // Добавляем юнит на новую землю
            }
            else
            {
                StartCoroutine(ReturnStartPoint()); // Если перемещение невозможно, возвращаем юнит в начальную точку
            }
        }

        RemoveMoveIndicator(); // Удаляем индикатор после завершения перемещения
    }

    /// <summary>
    /// Метод вызывается при нажатии на юнита. Если перемещение разрешено, отключаем коллайдер и начинаем перетаскивание.
    /// </summary>
    public void OnMouseDown()
    {
        if (isCanMove)
        {
            collider2D.enabled = false; // Отключаем коллайдер, чтобы избежать ложных столкновений во время перетаскивания
            isDraged = true; // Устанавливаем флаг перетаскивания
            startPoint = transform.position; // Сохраняем начальную позицию юнита

            // Показываем индикатор возможного перемещения
            if (Land.CurrentLand != null)
            {
                UpdateMoveIndicator(Land.CurrentLand);
            }
        }
    }

    /// <summary>
    /// Метод вызывается при отпускании юнита. Завершает перетаскивание и инициирует проверку перемещения.
    /// </summary>
    public void OnMouseUp()
    {
        if (isCanMove)
        {
            collider2D.enabled = true; // Включаем коллайдер снова
            isDraged = false; // Прекращаем перетаскивание
            MoveComplete(); // Завершаем перемещение юнита
        }
    }

    /// <summary>
    /// Короутина для возвращения юнита в начальную точку, если перемещение невозможно.
    /// </summary>
    /// <returns>IEnumerator для управления процессом возврата</returns>
    private IEnumerator ReturnStartPoint()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, 10 * Time.deltaTime); // Перемещаем юнит к начальной точке
            float distance = Vector3.Distance(transform.position, startPoint); // Проверяем расстояние до начальной точки
            if (distance < 0.1f) // Если достаточно близко, завершаем возврат
            {
                transform.position = startPoint; // Устанавливаем точную начальную позицию
                break;
            }
            yield return null; // Ждём до следующего кадра
        }
        collider2D.enabled = true; // Включаем коллайдер после возврата
        RemoveMoveIndicator(); // Удаляем индикатор после возврата
    }

    /// <summary>
    /// Метод для обновления индикатора перемещения рядом с юнитом. Отображает зелёный или красный кружочек в зависимости от возможности перемещения.
    /// </summary>
    /// <param name="targetLand">Целевая земля для проверки перемещения.</param>
    private void UpdateMoveIndicator(Land targetLand)
    {
        RemoveMoveIndicator(); // Удаляем текущий индикатор перед обновлением

        Vector3 indicatorPosition = transform.position + Vector3.up * 0.5f; // Позиция индикатора над юнитом

        if (FromLand.CheckBorderLand(targetLand)) // Если земля является соседней, отображаем зелёный кружочек
        {
            currentIndicator = Instantiate(greenCirclePrefab, indicatorPosition, Quaternion.identity, transform);
        }
        else // Если земля не является соседней, отображаем красный кружочек
        {
            currentIndicator = Instantiate(redCirclePrefab, indicatorPosition, Quaternion.identity, transform);
        }
    }

    /// <summary>
    /// Метод для удаления текущего индикатора перемещения.
    /// </summary>
    private void RemoveMoveIndicator()
    {
        if (currentIndicator != null)
        {
            Destroy(currentIndicator); // Удаляем индикатор, если он существует
            currentIndicator = null;
        }
    }
}
