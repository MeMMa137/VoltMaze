using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireAttach : MonoBehaviour
{
    public WirePickup wirePickup;
    public float attachRadius = 0.12f;
    public LayerMask holeLayer = ~0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && wirePickup != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D[] hits = Physics2D.OverlapCircleAll(mousePos, attachRadius, holeLayer);
            if (hits.Length == 0) return;

            // Prendo il foro più vicino
            Collider2D closest = null;
            float bestDist = float.MaxValue;
            foreach (var h in hits)
            {
                float dist = Vector2.Distance(mousePos, h.ClosestPoint(mousePos));
                if (dist < bestDist)
                {
                    bestDist = dist;
                    closest = h;
                }
            }

            if (closest == null) return;

            Vector3 attachPos = closest.ClosestPoint(mousePos);

            if (wirePickup.HasWire())
            {
                wirePickup.AttachWire(attachPos); 
            }
            else
            {
                wirePickup.StartWireAt(attachPos); 
            }
        }
    }
}
