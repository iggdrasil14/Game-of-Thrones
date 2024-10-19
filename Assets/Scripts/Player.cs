using JetBrains.Annotations;
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
public class Battle
{
    public List <Unit> unitsAttackers = new();
    public List <Unit> unitsDefenders = new();
    public Land land;
    public House houseAttackers;
    public House houseDefenders;

    public void BattleExecute()
    {
        int powerAttackers = 0;
        int powerDefenders = 0;
        for(int i = 0;i < unitsAttackers.Count; i++)
        {
            powerAttackers += unitsAttackers[i].power;
        }
        for(int i = 0; i <= unitsDefenders.Count; i++)
        {
            powerDefenders += unitsDefenders[i].power;
        }
        if(powerAttackers > powerDefenders)
        {
            
        }
        if(powerAttackers < powerDefenders)
        {

        }
        if(powerAttackers == powerDefenders)
        {

        }
    }
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


}
