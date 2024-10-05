using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Land : MonoBehaviour
{
    public static Land CurrentLand {  get; private set; }
    public List<Land> borderLand;
    public List<Water> borderWater;
    public List<Unit> unitsOnLand;
    public string name;
    public bool isSupply;
    public bool isCastle;
    public bool isShip;

    private void Awake()
    {
        for (int i = 0; i < unitsOnLand.Count; i++)
        {
            unitsOnLand[i].FromLand = this;
        }
    }

    public bool CheckBorderLand(Land land)
    {
        return borderLand.Contains(land);
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
