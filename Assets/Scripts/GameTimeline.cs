using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeline : MonoBehaviour
{
    public void StartRound()
    {
        Debug.Log("Click");
    }

    public void EndRound()
    {

    }

    public void Start()
    {
        Player stark = new Player();
        stark.house = House.Stark;
        stark.Setup();

        Player greyjoy = new Player();
        greyjoy.house = House.Greyjoy;
        greyjoy.Setup();

    }
}
