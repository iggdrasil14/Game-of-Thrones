public static class GameRules
{
    public static int ChangeArmyCount(int supply)
    {
        if (supply <= 1) { return 2; }
        if (supply == 2) { return 3; }
        if (supply <= 5) { return 4; }
        if (supply >= 6) { return 5; }
        return 0;
    }
    /// <summary>
    /// Сила армии королевства.
    /// </summary>
    public static int[] ArmyPower(int supply)
    {
        if (supply == 1) { return new int[] { 3, 2 }; }
        if (supply == 2) { return new int[] { 3, 2, 2 }; }
        if (supply == 3) { return new int[] { 3, 2, 2, 2 }; }
        if (supply == 4) { return new int[] { 3, 3, 2, 2 }; }
        if (supply == 5) { return new int[] { 4, 3, 2, 2 }; }
        if (supply >= 6) { return new int[] { 4, 3, 2, 2, 2 }; }
        return new int[] { 2, 2 };
    }
}
