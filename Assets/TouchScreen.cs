using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScreen : MonoBehaviour, IPointerClickHandler
{
    public Vector2 TouchPosition { get; private set; }

    private void Awake()
    {
        TouchPosition = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        TouchPosition = eventData.position;
    }
}