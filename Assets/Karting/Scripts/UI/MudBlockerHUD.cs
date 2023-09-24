using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBlockerHUD : MonoBehaviour
{
    public static MudBlockerHUD Instance;
    [SerializeField] private RectTransform displayRect;

    private void Start()
    {
        Instance = this;
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
