
using System;
using System.Collections.Generic;

[Serializable]
public class Player
{
    public static List<Player> Players = new List<Player>();
    public List<Land> lands = new();
    public string namePlayer;
    public House house;
    public int supply;
    public int armyCount;
    public List<HouseCard> houseCard;
    public GameTimeline timeline;

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
        if (land.isHasSupply)
        {
            supply++;
            armyCount = GameRules.ChangeArmyCount(supply);
        }
        lands.Add(land);
        land.Player = this;
    }
}
