using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Text alertText;
    public InputField username;
    public InputField password;
    public Button loginButton;
   
    private void Awake()
    {
        loginButton.interactable = false;
    }

    void Start()
    {
        alertText.text = "";
        username.text = "";
        password.text = "";
        CheckIfAllCrecentialsIsGiven();
    }

    public void CheckIfAllCrecentialsIsGiven()
    {
        if (username.text != "" && password.text != "")
        {
            loginButton.interactable = true;
        }
        else
        {
            loginButton.interactable = false;
        }
    }

    public void Update()
    {
        CheckIfAllCrecentialsIsGiven();
    }

    public void LinkToWebpage()
    {
        Application.OpenURL("https://snappy-roads.herokuapp.com/");
    }
}
