using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessageManager : MonoBehaviour
{
    public Text webErrorText;
    public Text infoText;
    public Canvas errorCanvas;
    
    void Awake()
    {
        errorCanvas.gameObject.SetActive(false);
    }

    public void SetAlertType(string alert)
    {
        if (alert == "ConnectFailure")
        {
            webErrorText.text = alert;
            infoText.text = "Lost connection to server!";
        }
        else if (alert == "NameResolutionFailure")
        {
            webErrorText.text = alert;
            infoText.text = "Please check internet connection!";
        }
        else if (alert == "ProtocolError")
        {
            webErrorText.text = alert;
            infoText.text = "Please restart the game!";
        }
        else if (alert == "UnknownError")
        {
            webErrorText.text = alert;
            infoText.text = "Error occured! Please try again";
        }
        else
        {
            webErrorText.text = alert;
            infoText.text = "";
        }
    }
}
