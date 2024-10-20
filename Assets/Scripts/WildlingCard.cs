using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildlingCard : MonoBehaviour
{
    public WesterosCardReference westerosCardReference;

    //public bool isVictory;
    /// <summary>
    /// ����� ����������� ����� "���� �� ������������" ��� ��������� ��������.
    /// </summary>
    public void MassingOnTheMilkwater()     // ���� �� ������������.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false) 
        {
            // ������ ������, ���� ������ �� ���� ������ ����� ����� ����, ���������� ��� ����� � ���������� ������ �����.
            // ��� ������, ���� ������ �� ���� ������ ������ ����� ����, ���������� �� 1 ����� �� ���� �����.
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ �������� �� ���� ���� ����� ����� ���� ����.
        }
    }
}
