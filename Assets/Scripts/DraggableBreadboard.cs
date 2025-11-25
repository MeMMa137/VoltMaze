using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableBreadboard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool dragging = false;
    private Vector3 offset;
    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    void Update()
    {
        
    }
}
