using System.Collections.Generic;
using Unity.Burst.Intrinsics;

public class Army
{
    public List<Unit> units = new();
    public Land land;
    public int armyPower;
    public void AddUnit(Unit unit) 
    {
        if(units.Count < armyPower)
        {
            units.Add(unit);
        }
    }

    public int AttackPower() 
    {
        int power = 0;
        for (int i = 0; i < units.Count; i++) 
        {
            power += units[i].power;
        }
        return power;
    }

}

public class Unit
{
    public int power;
}
public class Player
{
    public List<Land> lands = new();
    public List<Army> army = new();
    public string namePlayer;
    public int supply;
    public int armyCount;

    public void AddLand(Land land)
    {
        if (land.isSupply)
        {
            supply++;
            armyCount = GameRules.ChangeArmyCount(supply);
        }
        lands.Add(land);
    }

    public void AddArmy() 
    {
        if (army.Count < armyCount)
        {
            int[] armyPower = GameRules.ArmyPower(supply);
            Army newArmy = new Army();
            newArmy.armyPower = armyPower[army.Count - 1];
            army.Add(newArmy);
        }
    }

    public void MarchArmy(Land land)
    {

    }
}
