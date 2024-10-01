using UnityEngine;

public class Unit : MonoBehaviour 
{
    public int power;
    public Collider2D collider2D;
    public bool isCanMove;
    public bool isDraged;

    public void Update()
    {
        if (isDraged)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
    }

    public void MoveComplete(Land fromLand, Land toLand)
    {
        
    }

    public void OnMouseDown()
    {
        if (isCanMove) 
        {
            isDraged = true;
        }
    }

    public void OnMouseUp()
    {
        if (isCanMove)
        {
            isDraged = false;
        }
    }
}
