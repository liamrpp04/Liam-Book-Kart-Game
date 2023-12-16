using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSFX : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayButtonSound);       
    }

    private static void PlayButtonSound() => SFXManager.PlaySound("button");
}
