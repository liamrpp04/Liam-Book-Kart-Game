using UnityEngine;
using UnityEngine.UI;

public class MobileControlsHUD : MonoBehaviour
{
    public static MobileControlsHUD Instance;
    public bool IsMobile { get; private set; }

    [SerializeField] private Joystick joystick;
    [SerializeField] private InputButton btnNitro;
    [SerializeField] private InputButton btnItem;

    public float JoystickHorizontal => joystick.Horizontal;
    public float JoystickVertical => joystick.Vertical;

    public bool NitroPressedDown => btnNitro.PressedDown;
    public bool NitroIsPressed => btnNitro.IsPressed;
    public bool NitroPressedUp => btnNitro.PressedUp;

    public bool ItemPressedDown => btnItem.PressedDown;

    private void Awake()
    {
        Instance = this;

#if UNITY_ANDROID || UNITY_IOS
        IsMobile = true;
#else
        IsMobile = false;
#endif
        gameObject.SetActive(IsMobile);

    }
}
