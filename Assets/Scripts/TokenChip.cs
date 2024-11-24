using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenChip : MonoBehaviour
{
    public Land land;

    public void Start()
    {
        land.Player.timeline.AddTokenAtTurn(this);
    }

    public void OnDestroy()
    {
        land.Player.timeline.RemoveTokenAtTurn(this);
    }

    private void OnMouseDown()
    {
        land.isHasToken = false;
        Tokens.TokenMarch(land);
        Tokens.OutlineMovementLand(land);
        Destroy(gameObject);
        GameUI.Instance.buttonDone.SetActive(true);
    }
}
