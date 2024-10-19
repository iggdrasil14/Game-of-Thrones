using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenChip : MonoBehaviour
{
    public Land land;
    private void OnMouseDown()
    {
        land.isHasToken = false;
        Tokens.TokenMarch(land);
        Destroy(gameObject);
        GameUI.Instance.buttonDone.SetActive(true);
    }
}
