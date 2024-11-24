using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Trackers : MonoBehaviour
{
    public GameObject tokenRound;                           // ����� ������.
    public GameObject tokenCastle;                          // ����� ����������� ������ � ���������.
    public GameObject[] pointsRound;                        // ������ ����� ���� ����� ������������� ����� ������.
    public GameObject[] pointsCastle;                       // ������ ����� ���� ����� ������������� ����� �����.
    public int pointsIndexRound;                            // ����� �����.
    public int pointsIndexCastle;                           // ����� �����.
    public float speedToken = 100;                          // �������� ����������� ������.

    void Start()
    {
        //tokenRound.transform.position = pointsRound[1].transform.position;
        pointsIndexRound = 0;
        pointsIndexCastle = 0;
    }

    void Update()
    {
        tokenRound.transform.position = Vector3.MoveTowards(tokenRound.transform.position, pointsRound[pointsIndexRound].transform.position, speedToken * Time.deltaTime);
        tokenCastle.transform.position = Vector3.MoveTowards(tokenCastle.transform.position, pointsCastle[pointsIndexCastle].transform.position, speedToken * Time.deltaTime);
        VictoryChecker();
    }

    /// <summary>
    /// ����� ��������� ��������� �� ������� ������ - ������ 7 ������/��������� ��� ���������� 10 ������.
    /// </summary>
    public void VictoryChecker()
    {
        if(pointsIndexRound >= 10)
        {
            Debug.Log("���� ��������� - 10-� ����� ��������");
            // ������� ����� �� ������ ����
        }
        if (pointsIndexCastle >= 7) 
        {
            Debug.Log("���� ��������� - ����� �������� 7 ������/���������");
            // ����������� ����������.
        }
    }
}
