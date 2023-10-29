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


    void LateUpdate()
    {
        //if (_waitFrame)
        //{
        //    _waitFrame = false;
        //    return;
        //}

        if (PressedDown)
        {
            PressedDown = false;
        }
        else if (PressedUp)
        {
            PressedUp = false;
        }

        if (!IsPressed)
            return;

        //PressedDown = false;
        onHoldCallback?.Invoke();
    }
}
