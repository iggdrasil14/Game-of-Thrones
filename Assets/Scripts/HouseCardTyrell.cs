using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCardTyrell : HouseCard
{
    string houseName = "Tyrell";                    // Название Дома.
    public override void HeroesCard()
    {
        string cardDiscription = "Немедленно уничтожте одного из атакующих или защищающихся пеших воинов противника";
        string cardName = "Мейс Тирелл";            // Название героя.
        int cardPower = 4;                          // Сила героя.
        int cardSword = 0;                          // Сколько мечей на карте.
        int cardTower = 0;                          // Сколько башен на карте.
        bool isInHand = true;                       // Карта находится в руке у Игрока.
        bool isAbility = true;                      // Карта имеет уникальную способность.
    }

    //{

    //}
    //public void SerLorasTyrell()
    //{
    //    string cardDiscription = "Если в этом бою вы атаковали и победили, не снимайте приказ похода, а переложите его в захваченную область. Можете выполнить его снова в этом же раунде";
    //    string cardName = "Сер Лорас Тирелл";       // Название героя.
    //    int cardPower = 3;                          // Сила героя.
    //    int cardSword = 0;                          // Сколько мечей на карте.
    //    int cardTower = 0;                          // Сколько башен на карте.
    //    bool isInHand = true;                       // Карта находится в руке у Игрока.
    //    bool isAbility = true;                      // Карта имеет уникальную способность.
    //}
    public void SerGarlanTyrell()
    {
        string cardDiscription = null;
        string cardName = "Сер Гарлан Тирелл";      // Название героя.
        int cardPower = 2;                          // Сила героя.
        int cardSword = 2;                          // Сколько мечей на карте.
        int cardTower = 0;                          // Сколько башен на карте.
        bool isInHand = true;                       // Карта находится в руке у Игрока.
        bool isAbility = false;                     // Карта имеет уникальную способность.
    }
}
