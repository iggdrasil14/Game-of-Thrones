using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
public class Land : MonoBehaviour
{
    public static Land CurrentLand {  get; private set; }
    public static Land RetreatedLand { get; set; }
    public List<Land> borderLand;
    public List<Land> borderWater;
    public List<Unit> unitsOnLand;
    public string name;
    public bool isSupply;
    public bool isCastle;
    public bool isHasToken;
    public House house;     

    private void Awake()
    {
        for (int i = 0; i < unitsOnLand.Count; i++)
        {
            unitsOnLand[i].FromLand = this;
        }
    }

    public bool IsBattle()
    {
        for (int i = 0; i < unitsOnLand.Count; i++)
        {
            if(house != unitsOnLand[i].house)
            {
                return true;
            }
        }
        return false;
    }

    public void StartBattle()
    {
        Battle battle = new Battle();
        battle.land = this;
        for (int i = 0; i < unitsOnLand.Count; i++) 
        {
            if (unitsOnLand[i].house != house)
            {
                battle.unitsAttackers.Add(unitsOnLand[i]);
                battle.houseAttackers = unitsOnLand[i].house;
            }
            else
            {
                battle.unitsDefenders.Add(unitsOnLand[i]);
                battle.houseDefenders = unitsOnLand[i].house;
            }
        }
        battle.BattleExecute();
    }
    public void CompleteTurn()
    {
        for (int i = 0; i < unitsOnLand.Count; i++)
        {
            unitsOnLand[i].isCanMove = true;
        }
    }

    public bool CheckBorderLand(Land land)
    {
        return borderLand.Contains(land);
    }

    public bool CheckBorderWater(Land land)
    {
        for (int i = 0; i < borderWater.Count; i++)
        {
            if (borderWater[i].CheckBorderLand(land) & borderWater[i].unitsOnLand.Count > 0)
            {
                return true;
            } 
        }
        return false;
    }
    public void AddUnit(Unit unit)
    {
        if(unitsOnLand.Count < 4)
        {
            if (unitsOnLand.Contains(unit) == false) 
            {
                unitsOnLand.Add(unit);
            }
        }
    }

    public void RemoveUnit(Unit unit) 
    {
        unitsOnLand.Remove(unit);
    }

    private void OnMouseDown()
    {
        if(isHasToken == true)
        {
            return;
        }
        Vector2 tokenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var token = Instantiate(PlayerInput.Instance.tokenPrefab, tokenPosition, Quaternion.identity);
        token.land = this;
        isHasToken = true;
    }

    public void OnMouseEnter()
    {
        Debug.Log("Enter");
        CurrentLand = this;
    }

    public void OnMouseExit()
    {
        Debug.Log("Exit");
        CurrentLand = null;
    }
}
