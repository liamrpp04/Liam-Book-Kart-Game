using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MobileControlsHUD : MonoBehaviour
{
    public static MobileControlsHUD Instance;
    public bool IsMobile { get; private set; }

    [SerializeField] private Joystick joystick;
    [SerializeField] private InputButton btnNitro;
    [SerializeField] private InputButton btnItem;
    [SerializeField] private InputButton btnLookBack;
    [SerializeField] private Image rechargeOilItemImage;

    public float JoystickHorizontal => Mathf.Abs(joystick.Horizontal) > 0.1f ? joystick.Horizontal : 0;
    public float JoystickVertical => Mathf.Abs(joystick.Vertical) > 0.1f ? joystick.Vertical : 0;

    public bool NitroPressedDown => btnNitro.PressedDown;
    public bool NitroIsPressed => btnNitro.IsPressed;
    public bool NitroPressedUp => btnNitro.PressedUp;

    public bool ItemPressedDown => btnItem.PressedDown;

    public bool LookBackPressedDown => btnLookBack.PressedDown;
    public bool LookBackPressedUp => btnLookBack.PressedUp;


    public bool IsRechargingItem => rechargingOil;
    private bool rechargingOil;

    private void Awake()
    {
        Instance = this;

#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR  
        IsMobile = true;
#else
        IsMobile = false;
#endif
        gameObject.SetActive(IsMobile);

        rechargeOilItemImage.gameObject.SetActive(false);
    }

    public void RechargeOilItem()
    {
        if (rechargingOil)
            return;

        rechargingOil = true;
        rechargeOilItemImage.gameObject.SetActive(true);
        rechargeOilItemImage.fillAmount = 1;
    }

    private void Update()
    {
        if (Instance == null)
            return;

        if (!rechargingOil)
            return;

        rechargeOilItemImage.fillAmount -= Time.deltaTime / 15f;

        if (rechargeOilItemImage.fillAmount <= 0f)
        {
            var buttonRect = btnItem.GetComponent<RectTransform>();
            buttonRect.DOScale(Vector3.one * 1.05f, 0.1f).OnComplete(() => buttonRect.DOScale(Vector2.one, 0.1f));

            rechargeOilItemImage.gameObject.SetActive(false);
            rechargingOil = false;
        }

    }
}
