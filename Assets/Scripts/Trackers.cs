using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Trackers : MonoBehaviour
{
    public GameObject tokenRound;                           // Токен раунда.
    public GameObject tokenCastle;                          // Токен захваченных замков и крепостей.
    public GameObject[] pointsRound;                        // Массив точек куда может переместиться токен раунда.
    public GameObject[] pointsCastle;                       // Массив точек куда может переместиться токен замка.
    public int pointsIndexRound;                            // Номер точки.
    public int pointsIndexCastle;                           // Номер точки.
    public float speedToken = 100;                          // Скорость перемещения токена.

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
    /// Метод проверяет выполнены ли условия победы - захват 7 замков/крепостей или завершение 10 раунда.
    /// </summary>
    public void VictoryChecker()
    {
        if(pointsIndexRound >= 10)
        {
            Debug.Log("ИГРА ЗАКОНЧЕНА - 10-Й РАУНД ЗАКОНЧЕН");
            // подсчет очков по итогам игры
        }
        if (pointsIndexCastle >= 7) 
        {
            Debug.Log("ИГРА ЗАКОНЧЕНА - ИГРОК ЗАХВАТИЛ 7 ЗАМКОВ/КРЕПОСТЕЙ");
            // определение победителя.
        }
    }
}
