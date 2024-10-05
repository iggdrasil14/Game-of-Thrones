using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour 
{
    public Land FromLand {  get; set; }
    public Collider2D collider2D;
    public bool isCanMove;
    public bool isDraged;
    public int power;
    private Vector3 startPoint;

    public void Update()
    {
        if (isDraged)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
    }

    public void MoveComplete()
    {
        if (Land.CurrentLand != null) 
        {
            if (FromLand.CheckBorderLand(Land.CurrentLand)) 
            {
                FromLand.RemoveUnit(this);
                isCanMove = false;
                isDraged = false;
                FromLand = Land.CurrentLand;
                FromLand.AddUnit(this);
            }
            else
            {
                StartCoroutine(ReturnStartPoint());
            }
        }
    }

    public void OnMouseDown()
    {
        if (isCanMove) 
        {
            collider2D.enabled = false;
            isDraged = true;
            startPoint = transform.position;
        }
    }

    public void OnMouseUp()
    {
        if (isCanMove)
        {
            collider2D.enabled = true;
            isDraged = false;
            MoveComplete();
        }
    }

    private IEnumerator ReturnStartPoint()
    {
        while (true) 
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint, 10 * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, startPoint);
            if(distance < 0.1f)
            {
                transform.position = startPoint;
                break;
            }
            yield return null;
        }
        collider2D.enabled = true;
    }
}
