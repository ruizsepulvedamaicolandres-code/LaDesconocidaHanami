using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public GameObject MainMenu;
    public GameObject LevelsPanel;
    private GameObject CurentPanel;
    private GameObject NewPanel;

public void ShowMainMenu()
    {
        NewPanel.SetActive(true);
        CurentPanel.SetActive(false);
    }

public void ShowLevelsPanel()
    {
        NewPanel.SetActive(true);
        CurentPanel.SetActive(false);
    }
void Start()
{
    CurentPanel = MainMenu;
    NewPanel = LevelsPanel;
}

}



