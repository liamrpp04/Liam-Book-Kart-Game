using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject startGo;
    [SerializeField] private GameObject levelSelectionGo;
    [SerializeField] private Button[] levelButtons;

    private void Start()
    {
        GoToStart();
        CheckEnabledLevels();
    }

    private void CheckEnabledLevels()
    {
        int levelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        int i = 0;

        while (i < levelsUnlocked)
        {
            levelButtons[i].interactable = true;
            i++;
        }

        while (i < levelButtons.Length)
        {
            levelButtons[i].interactable = false;
            i++;
        }
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
