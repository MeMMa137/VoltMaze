using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WireAttach : MonoBehaviour
{
    public WirePickup wirePickup;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && wirePickup.HasWire())
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            Debug.Log(hit ? hit.name : "null");


            if ( hit !=null && hit.CompareTag("Hole"))
            {
                wirePickup.AttachWire(hit.transform.position);
            }
        }
    }
}
