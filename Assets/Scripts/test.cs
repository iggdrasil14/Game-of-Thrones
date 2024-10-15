using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var lands = FindObjectsByType<Land>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            for (int i = 0; i < lands.Length; i++) 
            {
                lands[i].CompleteTurn();
            }
        }
    }
}
