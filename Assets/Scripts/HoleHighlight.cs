using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using System.Xml.Serialization;

public class HoleHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SpriteRenderer sr;
    public Color highlightColor = Color.yellow;
    private Color originalColor;



    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sr.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sr.color = originalColor;
    }
}
