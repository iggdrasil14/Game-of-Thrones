using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public TokenChip tokenPrefab;
    public static PlayerInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
