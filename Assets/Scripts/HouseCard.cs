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
        string cardDiscription;             // �������� �����.
        string cardHouse;                   // �������� ����.
        string cardName;                    // �������� �����.
        int cardPower;                      // ���� �����.
        int cardSword;                      // ������� ����� �� �����.
        int cardTower;                      // ������� ����� �� �����.
        bool isInHand;                      // ����� ��������� � ���� � ������.
        bool isAbility;                     // ����� ����� ���������� �����������.
    }
}
