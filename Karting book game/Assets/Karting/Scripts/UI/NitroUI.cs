using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class NitroUI : MonoBehaviour
{
    public static NitroUI Instance;
    [SerializeField] private TMP_Text txtNitroPercent;
    [SerializeField] private Slider nitroPercentBar;
    [SerializeField] private Color colorEmpty, colorMedium, colorFull;
    [SerializeField] private float textColorEmptyAlpha = 0.25f;
    private void Awake()
    {
        Instance = this;
    }
    public void UpdateNitroUI(float nitroValue, float maxNitroValue)
    {
        nitroPercentBar.maxValue = maxNitroValue;
        nitroPercentBar.value = nitroValue;

        float percentvalue = nitroValue / maxNitroValue * 100;
        txtNitroPercent.text = Mathf.RoundToInt(percentvalue).ToString() + '%';
        UpdateNitroBarColor(nitroValue, maxNitroValue);
    }
    public void UpdateNitroBarColor(float nitroValue, float maxNitroValue)
    {
        float medium = maxNitroValue / 2;
        float lerpValue;
        Color targetColor;
        if (nitroValue < medium)
        {
            lerpValue = Mathf.InverseLerp(0, medium, nitroValue);
            targetColor = Color.Lerp(colorEmpty, colorMedium, lerpValue);
        }
        else
        {
            lerpValue = Mathf.InverseLerp(medium, maxNitroValue, nitroValue);
            targetColor = Color.Lerp(colorMedium, colorFull, lerpValue);
        }

        nitroPercentBar.fillRect.GetComponent<Image>().color = targetColor;
        if (nitroValue <= 0)
        {
            txtNitroPercent.color = new Color(colorEmpty.r,colorEmpty.g,colorEmpty.b,textColorEmptyAlpha);
        }
        else
        {
            txtNitroPercent.color = targetColor;
        } 
    }
}
