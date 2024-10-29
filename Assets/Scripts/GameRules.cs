public static class GameRules
{
    /// <summary>
    /// Определяет изменение количества армии на основе уровня снабжения.
    /// </summary>
    /// <param name="supply">Текущий уровень снабжения.</param>
    /// <returns>Новое количество армии.</returns>
    public static int ChangeArmyCount(int supply)
    {
        if (supply <= 1) { return 2; }                              // Установить значение количества армий на 2, если снабжение 1 или меньше.
        if (supply == 2) { return 3; }                              // Если снабжение равно 2, возвращаем 3.
        if (supply <= 5) { return 4; }                              // Если снабжение от 3 до 5, возвращаем 4.
        if (supply >= 6) { return 5; }                              // Если снабжение 6 или больше, возвращаем 5.
        return 0;                                                   // В остальных случаях возвращаем 0.
    }

    /// <summary>
    /// Определяет силу армии королевства на основе уровня снабжения.
    /// </summary>
    /// <param name="supply">Текущий уровень снабжения.</param>
    /// <returns>Массив сил отдельных отрядов армии.</returns>
    public static int[] ArmyPower(int supply)
    {
        if (supply == 1) { return new int[] { 3, 2 }; }             // Армия с количеством юнитов 3, 2.
        if (supply == 2) { return new int[] { 3, 2, 2 }; }          // Армия с количеством юнитов 3, 2, 2.
        if (supply == 3) { return new int[] { 3, 2, 2, 2 }; }       // Армия с количеством юнитов 3, 2, 2, 2.
        if (supply == 4) { return new int[] { 3, 3, 2, 2 }; }       // Армия с количеством юнитов 3, 3, 2, 2.
        if (supply == 5) { return new int[] { 4, 3, 2, 2 }; }       // Армия с количеством юнитов 4, 3, 2, 2.
        if (supply >= 6) { return new int[] { 4, 3, 2, 2, 2 }; }    // Армия с количеством юнитов 4, 3, 2, 2, 2.
        return new int[] { 2, 2 };                                  // Армия с количеством юнитов 2, 2.
    }
}


public static class Tokens
{
    /// <summary>
    /// Устанавливает возможность передвижения для всех юнитов на заданной территории.
    /// </summary>
    /// <param name="land">Территория, на которой находятся юниты.</param>
    public static void TokenMarch(Land land)
    {
        if (land.unitsOnLand.Count > 0)
        {
            foreach (Unit item in land.unitsOnLand)
            {
                item.isCanMove = true;                              // Юнит может двигаться.
            }
        }
    }
    public static void OutlineMovementLand(Land land)
    {
        for (int i = 0; i < land.borderLand.Count; i++) // для земли
        {
            if(land.borderLand[i].outlineMovement == null) 
            {
                continue;
            }
            land.borderLand[i].outlineMovement.SetActive(true);
        }

        for(int i = 0; i < land.borderWater.Count; i++)
        {
            if (land.borderWater[i].unitsOnLand.Count > 0)
            {
                foreach (var item in land.borderWater[i].borderLand) //item - land
                {
                    if (item.outlineMovement == null)
                    {
                        continue;
                    }
                    item.outlineMovement.SetActive(true);
                }
            }
        }
        // if (borderWater[i].CheckBorderLand(land) & borderWater[i].unitsOnLand.Count > 0)
    }
}
