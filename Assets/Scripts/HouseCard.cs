using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCard : MonoBehaviour
{
    public House house;
    public int power;
    public void Apply(Battle battle)
    {
        battle.AddCard(this);
    }
    public virtual void HeroesCard()
    {
        string cardDiscription;             // Описание карты.
        string cardHouse;                   // Название Дома.
        string cardName;                    // Название героя.
        int cardPower;                      // Сила героя.
        int cardSword;                      // Сколько мечей на карте.
        int cardTower;                      // Сколько башен на карте.
        bool isInHand;                      // Карта находится в руке у Игрока.
        bool isAbility;                     // Карта имеет уникальную способность.
    }
}
