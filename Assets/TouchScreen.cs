using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScreen : MonoBehaviour, IPointerClickHandler
{
    public Vector2 Position { get; private set; }

    private void Awake()
    {
        Position = Vector2.zero;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Position = eventData.position;
    }
}
