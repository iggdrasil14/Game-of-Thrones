using EPOOutline;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public HousePalete[] houseColor;
    public TokenChip tokenPrefab;
    public static PlayerInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void FillHousesColor()
    {
        var lands = FindObjectsOfType<Land>();
        foreach (var land in lands)
        {
            for(int i = 0; i < houseColor.Length; i++)
            {
                if (houseColor[i].house == land.house & land.outlineHouseBorder != null)
                {
                    //land.outlineHouseBorder.GetComponent<Outliner>().parameters
                }
            }
        }
    }

    [Serializable]
    public struct HousePalete
    {
        public House house;
        public Color color;
    }
}
