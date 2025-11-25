using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class HoleHighlight2D : MonoBehaviour
{
private SpriteRenderer sr;
private Color originalColor;
public Color highlightColor = Color.yellow;


void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos);
        if (hit != null && hit.gameObject == gameObject)
        {
            sr.color = highlightColor;
        }
        else
        {
            sr.color = originalColor;
        }
    }
}
