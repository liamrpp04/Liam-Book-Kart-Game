using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePositionHUD : MonoBehaviour
{
    public static RacePositionHUD Instance;
    [SerializeField] private TMPro.TMP_Text txtPos;
    [SerializeField] private TMPro.TMP_Text txtLap;

    private void Awake()
    {
        Instance = this;
    }

    public void SetPositionHUD(int pos, int lap)
    {
        txtPos.text = "Pos " + pos.ToString();
        txtLap.text = "Lap " + lap.ToString();
    }
}
