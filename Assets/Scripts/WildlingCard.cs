using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildlingCard : MonoBehaviour
{
    public WesterosCardReference westerosCardReference;
    public GameObject token;
    public GameObject[] points;
    public int pointsIndex;
    public float speed;
    public void Start()
    {
        token.transform.position = points[1].transform.position;
        pointsIndex = 1;
    }

    public void Update()
    {
        token.transform.position = Vector3.MoveTowards(token.transform.position, points[pointsIndex].transform.position, speed * Time.deltaTime);
    }

    public void GetCard()
    {
        print("����� �����");
    }
    //public bool isVictory;
    /// <summary>
    /// ����� ����������� ����� "���� �� ������������" ��� ��������� ��������.
    /// </summary>
    public void MassingOnTheMilkwater()                     // ���� �� ������������.
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
    /// <summary>
    /// ����� ����������� ����� "������ �� ������" ��� ��������� ��������.
    /// </summary>
    public void AKingBeyondTheWall()                        // ������ �� ������.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false)
        {
            // ������ ������, ��������� �� ��������� ������� ���� ������ �������.
            // ��� ������: � ������� ���� ������ ����� ��������� �� ��������� ������� ����� ������ ��� ����� (�� ������ ������).
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ ������������ �� ������ ������� ������ ����� ������� � �������� ��������������� ����� �������������.
        }
    }
    public void MammothRiders()                             // ��������� �� ��������.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false)
        {
            // ������ ������ ������ 3 ����� ������.
            // ��� ������: ������ �� 2 ����� ������.
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ ����� ������� �� ������ ������ 1 ����� ���� � ������� � �� ����.
        }
    }
    public void CrowKillers()                               // ������ �������.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false)
        {
            // ������ ������ �������� ���� ����� ������� ���������� �������. ������, ������� ����� ��������, ������.
            // ��� ������: �������� ������ ������� �� 2 ����� ����� ������. ������, ������� ����� ��������, ������.
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ ����� ��� �� �������� �� 2 ����� ����� ����� ������ ���������� ��������.
        }
    }
    public void TheHordeDescends()                          // ����������� ����.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false)
        {
            // ������ ������ ������ 2 ������ � ����� �� ����� ������ ��� ���������. ���� ����� ������� ���, ������ 2 ����� ������.
            // ��� ������: ������ �� 1 ������ ������.
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ ����� ������� ������ �� ������� �������� ����� � ����� ����������� ����� ��� ��������.
        }
    }
    public void SkinchangerScout()                          // ��������� ���������.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false)
        {
            // ������ ������ ������ 2 ������ � ����� �� ����� ������ ��� ���������. ���� ����� ������� ���, ������ 2 ����� ������.
            // ��� ������: ������ �� 1 ������ ������.
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ ����� ������� ������ �� ������� �������� ����� � ����� ����������� ����� ��� ��������.
        }
    }
    public void RattleshirtsRaiders()                       // ���������� �������� �������.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false)
        {
            // ������ ������ ��������� �� 2 ������� ����� �� ����� ��������� (�� ���� ����).
            // ��� ������: ��������� �� 1 ������� ����� �� ����� ��������� (�� ���� ����).
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ ������������ �� 1 ������� ������ �� ����� ��������� (�� ���� 6).
        }
    }
    public void SilenceAtTheWall()                          // ������ � �����.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false)
        {
            // ������ ������ �� ��������.
            // ��� ������: �� ��������.
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ �� ������������.
        }
    }
    public void PreemptiveRaid()                            // ��������� �����.
    {
        // ������ ��������:
        if (westerosCardReference.isVictory == false)
        {
            // ������ ������ �� ���� ����� ����
            // �) ������ 2 ����� ������, ����
            // �) ��������� �� 2 ������� �� ���� ����� �������, ��� � �� ��������� �������.
            // ��� ������: �� ��������.
        }

        // ������ ������� ������:
        if (westerosCardReference.isVictory == true)
        {
            // ������ ������ �� ��������� � ������ (� � ������������� ������ � ������� �� ������)
            // �� ��������� ����� ��������, ������� ��� �� �������� ����� � ����� 6.
        }
    }
}
