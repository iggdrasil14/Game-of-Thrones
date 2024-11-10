using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public event Action<HouseCard> ClickHouseCard;
    public event Action ClickValerySword;
    public static GameUI Instance { get; private set; }
    public GameObject buttonDone;
    public GameObject panelValerySword;

    private void Awake()
    {
        Instance = this;
    }

    public void EndMarch()
    {
        StartCoroutine(LandBattle());
    }

    public void OnClickHouseCard(HouseCard card)
    {
        ClickHouseCard?.Invoke(card);
    }

    public void OnClickValerySword()
    {
        ClickValerySword?.Invoke();
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
            ClickHouseCard += battle.AddCard;
            yield return new WaitWhile(() => BattlePredicate(battle));
            ClickHouseCard -= battle.AddCard;

            panelValerySword.SetActive(true);
            yield return null;

            yield return new WaitWhile(() => SwordValeryPredicate());
            battle.BattleExecute();
        }
        else 
        {
            Debug.Log("No battle");
            yield return null;
        }
    }

    private bool BattlePredicate(Battle battle)
    {
        //return battle.attackersCard == null & battle.defendersCard == null;
        return battle.attackersCard == null;
    }

    private bool SwordValeryPredicate()
    {
        return panelValerySword.activeInHierarchy;
    }
}
