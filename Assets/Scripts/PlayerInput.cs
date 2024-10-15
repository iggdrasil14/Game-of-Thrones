using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public TokenChip tokenPrefab;
    public static TokenChip TokenPrefab { get; private set; }

    private void Awake()
    {
        TokenPrefab = tokenPrefab;
    }
}
