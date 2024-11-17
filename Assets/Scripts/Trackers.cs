using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Trackers : MonoBehaviour
{
    public GameObject tokenRound;
    public GameObject[] pointsRound;
    public int pointsIndexRound;
    public float speedTokenRound;


    // Start is called before the first frame update
    void Start()
    {
        tokenRound.transform.position = pointsRound[1].transform.position;
        pointsIndexRound = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tokenRound.transform.position = Vector3.MoveTowards(tokenRound.transform.position, pointsRound[pointsIndexRound].transform.position, speedTokenRound * Time.deltaTime);
        //if (pointsIndexRound >= 10)
        //{
        //    Debug.Log("онаедю б хцпе!");
        //}
    }
}
