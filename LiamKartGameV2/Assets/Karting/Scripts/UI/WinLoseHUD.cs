using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseHUD : MonoBehaviour
{
    public static WinLoseHUD Instance;
    [SerializeField] private NotificationToast displayMessage;

    private void Awake()
    {
        Instance = this;

        displayMessage.gameObject.SetActive(false);
    }

    public void ShowWinMessage()
    {
        displayMessage.gameObject.SetActive(true);

        displayMessage.Initialize("CONGRATULATIONS, YOU WON!");
    }

    public void ShowLoseMessage()
    {
        displayMessage.gameObject.SetActive(true);

        displayMessage.Initialize("YOU LOSE");
    }
}
