using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject startGo;
    [SerializeField] private GameObject levelSelectionGo;

    private void Start()
    {
        GoToStart();
    }

    public void GoToSelection()
    {
        startGo.SetActive(false);
        levelSelectionGo.SetActive(true);
    }

    public void GoToStart()
    {
        startGo.SetActive(true);
        levelSelectionGo.SetActive(false);
    }
}
