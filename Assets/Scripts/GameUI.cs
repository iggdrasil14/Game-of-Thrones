using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }
    public GameObject buttonDone;
    private void Awake()
    {
        Instance = this;
    }
    public void EndTurn()
    {
        var lands = FindObjectsOfType<Land>();
        foreach (var land in lands) 
        {
            land.ResetOutline();
        }
        for (int i = 0; i < lands.Length; i++) 
        {
            if (lands[i].IsBattle()) 
            {
                lands[i].StartBattle();
                return;
            }
        }
    }
}
