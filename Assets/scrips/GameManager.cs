using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public GameObject MainMenu;
    public GameObject LevelsPanel;
    public GameObject CreditsPanel;
    public GameObject OptionsPanel;

    private GameObject currentPanel;

    public void Start()
    {
        currentPanel = MainMenu;
        MainMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        ChangePanel(MainMenu);
    }

    public void ShowCreditsPanel()
    {
        ChangePanel(CreditsPanel);
    }

    public void ShowLevelsPanel()
    {
        ChangePanel(LevelsPanel);
        MainMenu.SetActive(true);
    }

    public void ShowOptionsPanel()
    {
        ChangePanel(OptionsPanel);
        MainMenu.SetActive(true);
    }

    private void ChangePanel(GameObject newPanel)
    {
        currentPanel.SetActive(false);
        newPanel.SetActive(true);
        currentPanel = newPanel;
    }

}



