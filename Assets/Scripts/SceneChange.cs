using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OpenControlsMenu()
    {
        SceneManager.LoadScene("Controls-menu");
    }

    public void OpenCarSelectorCanvas()
    {
        FindObjectOfType<MainMenu>().carSelectorCanvas.gameObject.SetActive(true);
    }

    public void OpenLevelSelectorCanvas()
    {
        FindObjectOfType<MainMenu>().levelSelectorCanvas.gameObject.SetActive(true);
    }

    public void OpenRulesCanvas()
    {
        FindObjectOfType<MainMenu>().rulesCanvas.gameObject.SetActive(true);
    }

    public void OpenControlsCanvas()
    {
        FindObjectOfType<MainMenu>().controlsCanvas.gameObject.SetActive(true);
    }

    public void CloseCarSelectorCanvas()
    {
        FindObjectOfType<MainMenu>().carSelectorCanvas.gameObject.SetActive(false);
    }

    public void CloseLevelSelectorCanvas()
    {
        FindObjectOfType<MainMenu>().levelSelectorCanvas.gameObject.SetActive(false);
    }
    
    public void CloseRulesCanvas()
    {
        FindObjectOfType<MainMenu>().rulesCanvas.gameObject.SetActive(false);
    }

    public void CloseControlsCanvas()
    {
        FindObjectOfType<MainMenu>().controlsCanvas.gameObject.SetActive(false);
    }

    public void CloseErrorCanvas()
    {
        FindObjectOfType<ErrorMessageManager>().errorCanvas.gameObject.SetActive(false);
    }

    public void OpenMainMenu()
    {
        FindObjectOfType<PlayerStatistics>().IncreasePlayerData();
        FindObjectOfType<APIManager>().UpdatePlayerData();
        SceneManager.LoadScene("Main-menu");
    }

    public void PlayerQuitGameWithoutFinishingLevel()
    {
        FindObjectOfType<PlayerStatistics>().IncreaseGameTimes();
        FindObjectOfType<APIManager>().UpdatePlayerData();
        SceneManager.LoadScene("Main-menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        if(Game_manager.manager.currentLevel.level == "Savannah")
        {
            SceneManager.LoadScene("Game-savannah");
        }

        else if(Game_manager.manager.currentLevel.level == "City")
        {
            SceneManager.LoadScene("Game-city");
        }

        else if (Game_manager.manager.currentLevel.level == "Mountains")
        {
            SceneManager.LoadScene("Game-mountains");
        }

        TimeController.time = 0;
        PenaltyController.penaltySeconds = 0;
        Game_manager.manager.alertText = "";
    }
}
