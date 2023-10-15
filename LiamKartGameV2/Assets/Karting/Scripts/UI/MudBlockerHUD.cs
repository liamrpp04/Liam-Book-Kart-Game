using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MudBlockerHUD : MonoBehaviour
{
    public static MudBlockerHUD Instance;
    [SerializeField] private RectTransform displayRect;
    [SerializeField] private TMP_Text displayText;

    private void Start()
    {
        Instance = this;

        displayText.text = (MobileControlsHUD.Instance.IsMobile) ? "TAB" : "SPACE";

        Hide();
    }

    public static void Show()
    {
        Instance.displayRect.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        Instance.displayRect.gameObject.SetActive(false);
    }
}
