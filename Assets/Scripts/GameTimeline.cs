using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeline : MonoBehaviour
{
    public List<Player> players;
    // public List<Turn> turns; - эту строчку заменил на строку ниже из за ошибки
    // NullReferenceException: Object reference not set to an instance of an object
    // GameTimeline.Start() (at Assets/Scripts/GameTimeline.cs:28)
    public List<Turn> turns = new List<Turn>();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RoundProcess());
        }
    }

    public void StartRound()
    {
        Debug.Log("Click");
        StartCoroutine(RoundProcess());
    }

    public void EndRound()
    {

    }

    public void Start()
    {
        for (int i = 0; i < players.Count; i++) 
        {
            players[i].Setup();
        }

        turns.Add(new RaidTurn());
        turns.Add(new MarchTurn());
        turns.Add(new SupportTurn());
        turns.Add(new DefenseTurn());
        turns.Add(new CrownTurn());
    }

    public void AddTokenAtTurn(TokenChip tokenChip)
    {
        turns[1].AddPlayerToGame(tokenChip.land.Player);
    }

    public void RemoveTokenAtTurn(TokenChip tokenChip)
    {
        turns[1].RemovePlayerFromGame(tokenChip.land.Player);
    }

    private IEnumerator RoundProcess()
    {
        int index = 1;
        yield return new WaitWhile(turns[index].IsCompleted);
        Debug.Log("MarchToken");
    }
}
