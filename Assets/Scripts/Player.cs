
using System.Collections.Generic;
using UnityEngine;

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
        for(int i = 0; i < unitsDefenders.Count; i++)
        {
            powerDefenders += unitsDefenders[i].power;
        }
        if(powerAttackers > powerDefenders)
        {
            Debug.Log("Атакующие победили!");
            for(int i = 0; i < unitsDefenders.Count; i++)
            {
                unitsDefenders[i].isCanMove = true;
                unitsDefenders[i].isRetreated = true;
            }
            land.Repaint(PlayerInput.Instance.GetColor(houseAttackers));
        }
        if(powerAttackers < powerDefenders)
        {
            Debug.Log("Защитники победили!");
            for (int i = 0; i < unitsAttackers.Count; i++)
            {
                unitsAttackers[i].Retreat();
            }
        }
        if(powerAttackers == powerDefenders)
        {
            Debug.Log("Ничья");
            if (Random.value >= 0.5f)
            {
                Debug.Log("Атакующие победили!");
                for (int i = 0; i < unitsDefenders.Count; i++)
                {
                    unitsDefenders[i].isCanMove = true;
                    unitsDefenders[i].isRetreated = true;
                }
            }
            else
            {
                Debug.Log("Защитники победили!");
                for (int i = 0; i < unitsAttackers.Count; i++)
                {
                    unitsAttackers[i].Retreat();
                }
            }
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
}
