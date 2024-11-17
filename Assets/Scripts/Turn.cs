using System.Collections.Generic;

public abstract class Turn
{
    public List<Player> playerList = new();
    public bool IsCompleted()
    {
        return false;
        // условия завершения хода.
    }

    public bool IsContained(Player player)
    {
        return playerList.Contains(player);
    }
}

public class RaidTurn : Turn
{

}

public class MarchTurn : Turn
{

}

public class SupportTurn : Turn
{

}

public class DefenseTurn : Turn
{

}

public class CrownTurn : Turn
{

}
