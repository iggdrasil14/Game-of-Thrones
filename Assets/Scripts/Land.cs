using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Land : MonoBehaviour
{
    public List<Land> borderLand;
    public string name;
    public bool isSupply;
    public bool isCastle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp()
    {
        Debug.Log(name);
    }

}
