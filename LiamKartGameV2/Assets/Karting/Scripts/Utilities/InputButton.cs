using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Action onHoldCallback;
    public bool PressedDown { get; private set; }
    public bool IsPressed { get; private set; }
    public bool PressedUp { get; private set; }

    private bool _waitFrame = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        PressedDown = true;
        IsPressed = true;
        PressedUp = false;

        _waitFrame = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
        PressedDown = false;
        PressedUp = true;

        _waitFrame = true;
    }


    void Update()
    {
        if (_waitFrame)
        {
            _waitFrame = false;
            return;
        }

        if (PressedUp)
        {
            PressedUp = false;
            return;
        }

        if (!IsPressed)
            return;

        PressedDown = false;
        onHoldCallback?.Invoke();
    }
}
