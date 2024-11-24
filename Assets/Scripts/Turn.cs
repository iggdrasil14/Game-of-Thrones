using System.Collections.Generic;

public abstract class Turn
{
    public List<Player> playerList = new();
    public bool IsCompleted()
    {
        return playerList.Count > 0;
    }

    public bool IsContained(Player player)
    {
        return playerList.Contains(player);
    }

    public void AddPlayerToGame(Player player)
    {
        if (IsContained(player) == false) 
        {
            playerList.Add(player);
        }
    }

    public void RemovePlayerFromGame(Player player) 
    {
        playerList.Remove(player);
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
