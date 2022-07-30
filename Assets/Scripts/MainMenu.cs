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
    public Canvas carSelectorCanvas;
    public Canvas levelSelectorCanvas;
    public Canvas rulesCanvas;
    public Canvas controlsCanvas;
   
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
        if(Game_manager.manager.alertText != "")
        {
            FindObjectOfType<ErrorMessageManager>().errorCanvas.gameObject.SetActive(true);
            FindObjectOfType<ErrorMessageManager>().SetAlertType(Game_manager.manager.alertText);
        }
        selectedCar.text = "Selected car: " + Game_manager.manager.currentCar.carName;
        selectedLevel.text = "Selected level: " + Game_manager.manager.currentLevel.level;
        CheckIfCarAndLevelIsSelected();
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
