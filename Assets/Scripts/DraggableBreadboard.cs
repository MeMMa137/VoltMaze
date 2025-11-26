using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableBreadboard : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private bool dragging = false;
    private Vector3 offset;
    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
