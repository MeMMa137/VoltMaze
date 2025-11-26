using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePickup : MonoBehaviour
{

    [Header("wire dot lolololol")]
    public GameObject wirePrefab;
    private GameObject activateDot;
    
    void Update()
    {
        if (activateDot != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            activateDot.transform.position = mousePos;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DropWire();
        }
    }

    public bool HasWire()
    {
        return activateDot != null;
    }

    void OnMouseDown()
    {
        if (activateDot == null)
        {
            PickupWire();
        }
    }

    void PickupWire()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        activateDot = Instantiate (wirePrefab, mousePos, Quaternion.identity);
    }

    void DropWire()
    {
        if(activateDot != null)
        {
            Destroy(activateDot);
            activateDot = null;
        }
    }

    public void AttachWire (Vector3 position)
    {
        if (activateDot != null)
        {
            activateDot.transform.position = position;
        }
    }
}
