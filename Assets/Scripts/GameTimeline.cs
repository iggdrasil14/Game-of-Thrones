using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeline : MonoBehaviour
{
    public List<Player> players;
    public List<Turn> turns;
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

    private IEnumerator RoundProcess()
    {
        int index = 0;
        yield return new WaitWhile(turns[index].IsCompleted);
    }
}
