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
    public void SelectHouseCard(Battle battle)
    {

    }
    public void EndMarch()
    {

    }
    public void EndTurn()
    {

    }

    private IEnumerator LandBattle()
    {
        //completeMove
        var lands = FindObjectsOfType<Land>();
        foreach (var land in lands)
        {
            land.ResetOutline();
        }
        Battle battle = null;
        for (int i = 0; i < lands.Length; i++)
        {
            if (lands[i].IsBattle())
            {
                battle = new Battle();
                lands[i].SetupBattle(battle);
                break;
            }
        }
        if(battle != null)
        {
            yield return new WaitWhile(() => BattlePredicate(battle));
            Debug.Log("Complete - start battle");
        }
        else 
        {
            Debug.Log("No battle");

            yield return null;
        }
    }

    private bool BattlePredicate(Battle battle)
    {
        return battle.attackersCard == null & battle.defendersCard == null;
    }
}
