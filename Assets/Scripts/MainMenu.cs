using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Text selectedCar;
    public Text selectedLevel;
    public Text webErrorText;
    public Canvas carSelectorCanvas;
    public Canvas levelSelectorCanvas;
    public Canvas rulesCanvas;
    public Canvas controlsCanvas;
    string alert;

    private void Awake()
    {
        playButton.interactable = false;
        carSelectorCanvas.gameObject.SetActive(false);
        levelSelectorCanvas.gameObject.SetActive(false);
        rulesCanvas.gameObject.SetActive(false);
        controlsCanvas.gameObject.SetActive(false);
    }
   
    private void Start()
    {
        alert = Game_manager.manager.alertText;
        selectedCar.text = "Selected car: " + Game_manager.manager.currentCar.carName;
        selectedLevel.text = "Selected level: " + Game_manager.manager.currentLevel.level;
        CheckAlertType();
        CheckIfCarAndLevelIsSelected();
    }
    
    public void CheckAlertType()
    {
        if (alert == "ConnectFailure")
        {
            webErrorText.text = alert + "\n" + "Lost connection to server!";
        }
        else if (alert == "NameResolutionFailure")
        {
            webErrorText.text = alert + "\n" + "Please check internet connection!";
        }
        else if (alert == "ProtocolError")
        {
            webErrorText.text = alert + "\n" + "Please restart the game!";
        }
    }
    
    public void CheckIfCarAndLevelIsSelected()
    {
        if (selectedCar.text.Length > 15 && selectedLevel.text.Length > 18)
        {
            playButton.interactable = true;
        }
        else
        {
            playButton.interactable = false;
        }
    }

    void Update()
    {
        CheckIfCarAndLevelIsSelected();
    }
}
