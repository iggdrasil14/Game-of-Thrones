using System.Collections;
using UnityEngine;
public enum House
{
    Stark,
    Greyjoy,
    Lannister,
    Tyrell,
    Martell,
    Baratheon,
    Neutral
}
public class Unit : MonoBehaviour
{
    private Land oldLand;                                   //
    private Land fromLand;
    public Land FromLand {
        get => fromLand;
        set 
        {
            oldLand = fromLand;
            fromLand = value;
        } }                      // Земля с которой начинается движение  юнита.
    public House house;
    public Collider2D collider2D;                           // Коллайдер юнита для определения столкновений.
    public bool isCanMove;                                  // Флаг определяет может ли юнит двигаться.
    public bool isDraged;                                   // Флаг определяет перетаскивается ли юнит игроком.
    public int power;                                       // Сила юнита.
    private Vector3 startPoint;                             // Точка начала перемещения юнита.

    public GameObject greenCirclePrefab;                    // ChatGPT. Индикация юнита при перемещении. Префаб зелёного круга, если перемещение доступно.
    public GameObject redCirclePrefab;                      // ChatGPT. Индикация юнита при перемещении. Префаб красного круга, если перемещение доступно.
    private GameObject currentIndicator;                    // ChatGPT. Индикация юнита при перемещении. Текущий индикатор, отображаемый рядом с юнитом.

    public void Update()
    {
        if (isDraged)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Получаем текущую позицию мыши в мировых координатах
            transform.position = mousePosition;             // Перемещаем юнит к позиции мыши.
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
        if (Land.CurrentLand != null)                       // Проверяем, выбрана ли новая земля
        {
            if(house == Land.CurrentLand.house)
            {
                bool isReturn = true;
                if (FromLand.CheckBorderLand(Land.CurrentLand) | FromLand.CheckBorderWater(Land.CurrentLand)) // Проверяем, граничит ли новая земля с текущей
                {
                    int[] armyPower = GameRules.ArmyPower(0);
                    for (int i = 0; i < armyPower.Length; i++)
                    {
                        if (armyPower[i] > Land.CurrentLand.unitsOnLand.Count)
                        {
                            FromLand.RemoveUnit(this);          // Убираем юнит с текущей земли
                            isCanMove = false;                  // Запрещаем дальнейшее движение
                            isDraged = false;                   // Прекращаем перетаскивание
                            FromLand = Land.CurrentLand;        // Обновляем текущую землю юнита
                            FromLand.AddUnit(this);             // Добавляем юнит на новую землю
                            isReturn = false;
                            break;
                        }
                    }
                }
                if (isReturn == true)
                {
                    StartCoroutine(ReturnStartPoint());         // Если перемещение невозможно, возвращаем юнит в начальную точку
                }
            }
            else
            {
                FromLand.RemoveUnit(this);          // Убираем юнит с текущей земли
                isCanMove = false;                  // Запрещаем дальнейшее движение
                isDraged = false;                   // Прекращаем перетаскивание
                FromLand = Land.CurrentLand;        // Обновляем текущую землю юнита
                FromLand.AddUnit(this);             // Добавляем юнит на новую землю
            }
 
        }
        RemoveMoveIndicator();                              // Удаляем индикатор после завершения перемещения
    }

    /// <summary>
    /// Метод вызывается при нажатии на юнита. Если перемещение разрешено, отключаем коллайдер и начинаем перетаскивание.
    /// </summary>
    public void OnMouseDown()
    {
        if (isCanMove)
        {
            collider2D.enabled = false;                     // Отключаем коллайдер, чтобы избежать ложных столкновений во время перетаскивания
            isDraged = true;                                // Устанавливаем флаг перетаскивания
            startPoint = transform.position;                // Сохраняем начальную позицию юнита
            if (Land.CurrentLand != null)                   // Показываем индикатор возможного перемещения
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
            collider2D.enabled = true;                      // Включаем коллайдер снова
            isDraged = false;                               // Прекращаем перетаскивание
            MoveComplete();                                 // Завершаем перемещение юнита
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
            if (distance < 0.1f)                            // Если достаточно близко, завершаем возврат
            {
                transform.position = startPoint;            // Устанавливаем точную начальную позицию
                break;
            }
            yield return null;                              // Ждём до следующего кадра
        }
        collider2D.enabled = true;                          // Включаем коллайдер после возврата
        RemoveMoveIndicator();                              // Удаляем индикатор после возврата
    }

    /// <summary>
    /// ChatGPT. Индикация юнита при перемещении. Метод для обновления индикатора перемещения рядом с юнитом. Отображает зелёный или красный кружочек в зависимости от возможности перемещения.
    /// </summary>
    /// <param name="targetLand">Целевая земля для проверки перемещения.</param>
    private void UpdateMoveIndicator(Land targetLand)
    {
        // Удаляем текущий индикатор перед обновлением
        RemoveMoveIndicator();
        // Позиция индикатора над юнитом
        Vector3 indicatorPosition = transform.position + Vector3.up * 0.5f;
        // Если земля является соседней, отображаем зелёный круг.
        if (FromLand.CheckBorderLand(targetLand))           
        {
            currentIndicator = Instantiate(greenCirclePrefab, indicatorPosition, Quaternion.identity, transform);
        }
        // Если земля не является соседней, отображаем красный круг.
        else
        {
            currentIndicator = Instantiate(redCirclePrefab, indicatorPosition, Quaternion.identity, transform);
        }
    }

    /// <summary>
    /// ChatGPT. Индикация юнита при перемещении. Метод для удаления текущего индикатора перемещения.
    /// </summary>
    private void RemoveMoveIndicator()
    {
        if (currentIndicator != null)
        {
            // Удаляем индикатор, если он существует
            Destroy(currentIndicator); 
            currentIndicator = null;
        }
    }

    public void Retreat()
    {
        StartCoroutine(ReturnStartPoint());
        FromLand.RemoveUnit(this);
        FromLand = oldLand;
        FromLand.AddUnit(this);
    }
}
