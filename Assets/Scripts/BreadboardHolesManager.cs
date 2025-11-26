using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadboardHolesManager : MonoBehaviour
{

    [Header("Emptry obj w holes")]

    public List<Transform> rowParents;

    [Header("Higlight")] 
    public Color highlightColor = Color.yellow;
    private List<SpriteRenderer> holes = new List<SpriteRenderer>();

    void Start()
    {
        holes.Clear();
        foreach(Transform row in rowParents)
        {
            foreach(Transform hole in row)
            {
                SpriteRenderer sr = hole.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    holes.Add(sr);
                }
            }
        }
    }
    void Update()
    {
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        foreach (SpriteRenderer hole in holes)
        {
            Collider2D col = hole.GetComponent<Collider2D>();
            if (col != null && col.OverlapPoint(mousePos))
            {
                hole.color = highlightColor;
            }
            else
            {
                hole.color = Color.white;
            }
        }
    }
}
