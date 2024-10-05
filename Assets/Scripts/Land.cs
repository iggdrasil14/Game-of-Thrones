using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Land : MonoBehaviour
{
    public List<Land> borderLand;
    public List<Water> borderWater;
    public List<Unit> unitsOnLand;
    public string name;
    public bool isSupply;
    public bool isCastle;
    public bool isShip;

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

    public void OnMouseEnter()
    {
        Debug.Log("Enter");
    }

    public void OnMouseExit()
    {
        Debug.Log("Exit");
    }
}
