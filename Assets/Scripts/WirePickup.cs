using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePickup : MonoBehaviour
{
    public GameObject wirePrefab; 
    private GameObject currentWire;
    private LineRenderer lr;
    private Vector3 pointA;
    private bool dragging = false;

    void Update()
    {
        if (currentWire != null && dragging && lr != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -1;
            lr.SetPosition(1, mousePos);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DropWire();
        }
    }

    public void StartWireAt(Vector3 startPos)
    {
        if (currentWire != null) return;

        currentWire = Instantiate(wirePrefab, startPos, Quaternion.identity);
        lr = currentWire.GetComponent<LineRenderer>();
        if (lr == null)
        {
            lr.sortingLayerName = "Wires";
            lr.sortingOrder = 100;
            lr.startWidth = 0.05f;
            lr.endWidth = 0.05f;
        }

        pointA = startPos;
        lr.positionCount = 2;
        lr.SetPosition(0, pointA);
        lr.SetPosition(1, pointA);
        dragging = true;
    }

    public void AttachWire(Vector3 endPos)
    {
        if (currentWire == null) return;

        endPos.z = -1;
        lr.SetPosition(1, endPos);
        currentWire = null;
        lr = null;
        dragging = false;
    }

    public void DropWire()
    {
        if (currentWire != null)
        {
            Destroy(currentWire);
            currentWire = null;
            lr = null;
            dragging = false;
        }
    }

    public bool HasWire()
    {
        return currentWire != null;
    }
}
