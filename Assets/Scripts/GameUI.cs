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
    public void Attack()
    {
        Battle battle = new Battle();
        var lands = FindObjectOfType<Land>();

    }
}
