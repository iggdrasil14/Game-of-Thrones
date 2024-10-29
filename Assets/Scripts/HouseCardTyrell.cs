using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCardTyrell : HouseCard
{
    string houseName = "Tyrell";                    // �������� ����.
    public override void HeroesCard()
    {
        string cardDiscription = "���������� ��������� ������ �� ��������� ��� ������������ ����� ������ ����������";
        string cardName = "���� ������";            // �������� �����.
        int cardPower = 4;                          // ���� �����.
        int cardSword = 0;                          // ������� ����� �� �����.
        int cardTower = 0;                          // ������� ����� �� �����.
        bool isInHand = true;                       // ����� ��������� � ���� � ������.
        bool isAbility = true;                      // ����� ����� ���������� �����������.
    }

    //{

    //}
    //public void SerLorasTyrell()
    //{
    //    string cardDiscription = "���� � ���� ��� �� ��������� � ��������, �� �������� ������ ������, � ���������� ��� � ����������� �������. ������ ��������� ��� ����� � ���� �� ������";
    //    string cardName = "��� ����� ������";       // �������� �����.
    //    int cardPower = 3;                          // ���� �����.
    //    int cardSword = 0;                          // ������� ����� �� �����.
    //    int cardTower = 0;                          // ������� ����� �� �����.
    //    bool isInHand = true;                       // ����� ��������� � ���� � ������.
    //    bool isAbility = true;                      // ����� ����� ���������� �����������.
    //}
    public void SerGarlanTyrell()
    {
        string cardDiscription = null;
        string cardName = "��� ������ ������";      // �������� �����.
        int cardPower = 2;                          // ���� �����.
        int cardSword = 2;                          // ������� ����� �� �����.
        int cardTower = 0;                          // ������� ����� �� �����.
        bool isInHand = true;                       // ����� ��������� � ���� � ������.
        bool isAbility = false;                     // ����� ����� ���������� �����������.
    }
}
