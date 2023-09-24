using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePositionHUD : MonoBehaviour
{
    public static RacePositionHUD Instance;
    [SerializeField] private TMPro.TMP_Text txtPos;

    private void Awake()
    {
        Instance = this;
    }

    public void SetPositionHUD(int pos)
    {
        txtPos.text = pos.ToString();
    }
}
