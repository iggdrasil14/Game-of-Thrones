
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
    public List <Unit> unitsAttackers = new();
    public List <Unit> unitsDefenders = new();
    public Land land;
    public House houseAttackers;
    public House houseDefenders;
    public HouseCard attackersCard;
    public HouseCard defendersCard;
    public bool atteckersUseValerySword;
    public bool defendersUseValerySword;

    public void AddCard(HouseCard card)
    {
        if(card.house == houseAttackers)
        {
            attackersCard = card;
        }
        if (card.house == houseDefenders) 
        {
            defendersCard = card;
        }
    }

    public void AddValerySword()
    {
        atteckersUseValerySword = true;
    }

    public void BattleExecute()
    {
        int powerAttackersNoneCard = 0;
        int powerDefendersNoneCard = 0;
        int powerAttackers = 0;
        int powerDefenders = 0;
        for (int i = 0;i < unitsAttackers.Count; i++)
        {
            powerAttackers += unitsAttackers[i].power;
        }
        powerAttackersNoneCard = powerAttackers;
        powerAttackers += attackersCard.power;
        if(atteckersUseValerySword == true)
        {
            powerAttackers += 1;
        }

        for(int i = 0; i < unitsDefenders.Count; i++)
        {
            powerDefenders += unitsDefenders[i].power;
        }
        powerDefendersNoneCard = powerDefenders;
        //powerDefenders += defendersCard.power;
        Debug.Log($"Сила атакующей армии {powerAttackersNoneCard} и сила карты {attackersCard.power}.");
        Debug.Log($"Сила защищающейся армии {powerDefendersNoneCard} и сила карты {0}.");
        if(atteckersUseValerySword == true)
        {
            Debug.Log($"Сила Валирийского меча атакующих +1.");
        }
        if (defendersUseValerySword == true)
        {
            Debug.Log($"Сила Валирийского меча защищающихся +1.");
        }

        if (powerAttackers > powerDefenders)
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
    public string namePlayer;
    public House house;
    public int supply;
    public int armyCount;
    public static List<Player> Players = new List<Player>();

    public void Setup()
    {
        Players.Add(this);
        for (int i = 0; i < Land.Lands.Count; i++) 
        {
            if(house == Land.Lands[i].house && !Land.Lands[i].isWater) 
            {
                AddLand(Land.Lands[i]);
            }
        }
    }

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
