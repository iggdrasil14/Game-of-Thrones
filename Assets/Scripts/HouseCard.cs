using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCard : MonoBehaviour
{
    public House house;
    public string cardDiscription;             // �������� �����.
    public string cardName;                    // �������� �����.
    public int power;
    public int sword;
    public int tower;
 
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
