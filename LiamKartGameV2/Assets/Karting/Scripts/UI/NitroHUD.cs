using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NitroHUD : MonoBehaviour
{
    public static NitroHUD Instance;

    [SerializeField] private RectTransform panel;
    [SerializeField] private TextMeshProUGUI txtCount;

    [SerializeField] private Slider nitroBar;
    [SerializeField] private TextMeshProUGUI txtNitroPercent;

    [SerializeField] private Color colorEmpty, colorMedium, colorFull;
    [SerializeField] private Graphic[] graphics;

    public void Show() => panel.gameObject.SetActive(true);
    public void Hide() => panel.gameObject.SetActive(false);

    private void Awake()
    {
        Instance = this;
        //Hide();
    }

    public void SetCountText(int count)
    {
        if (count == 0)
        {
            Hide();
            return;
        }
        Show();
        txtCount.text = count.ToString();
    }

    void SetColor(float value, float maxValue)
    {
        float medium = maxValue / 2;
        Color target;
        float t;
        if (value < medium)
        {
            t = Mathf.InverseLerp(0, medium, value);
            target = Color.Lerp(colorEmpty, colorMedium, t);
        }
        else
        {
            t = Mathf.InverseLerp(medium, maxValue, value);
            target = Color.Lerp(colorMedium, colorFull, t);
        }

        //nitroBar.image.color = target;
        foreach (var graphic in graphics)
        {
            //graphic.color = target;
            graphic.color = GetColorWithAlpha(target, graphic.color.a);
        }
    }

    Color GetColorWithAlpha(Color target, float alpha)
    {
        target.a = alpha;
        return target;
    }

    public void SetNitroValueHUD(float value, float maxValue)
    {
        nitroBar.maxValue = maxValue;
        nitroBar.value = value;

        float valuePercent = value * 100f / maxValue;
        txtNitroPercent.text = valuePercent.ToString("0") + "%";

        SetColor(value, maxValue);
    }

}
