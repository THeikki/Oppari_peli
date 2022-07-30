using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class APIManager : MonoBehaviour
{
    public void LoginToGame()
    {
        // API request body
        //string url = String.Format("http://localhost:5000/api/users/login");
        string url = String.Format("https://oppari-api.herokuapp.com/api/users/login");
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.ContentType = "application/json";
        request.Method = "POST";

        try
        {
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"username\":\"" + FindObjectOfType<Login>().username.text + "\",\"password\":\"" + FindObjectOfType<Login>().password.text + "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
        catch(WebException error)
        {
            Debug.Log(error.Status);
        }

        // Get API response
        try
        {
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();

                if (result.Length > 40)
                {
                    string token;
                    string id;
                    string[] resultParts = result.Split(':', ',');

                    token = resultParts[1].Trim('"');
                    id = resultParts[3].Trim('"', '}');
                    PlayerPrefs.SetString("playerToken", token);
                    PlayerPrefs.SetString("playerId", id);
                    PlayerPrefs.Save();

                    SceneManager.LoadScene("Main-menu");
                    GetPlayerData();
                }

                else
                {
                    FindObjectOfType<Login>().username.text = "";
                    FindObjectOfType<Login>().password.text = "";

                    string alert;
                    string[] resultParts = result.Split(':');
                    alert = resultParts[1].Trim('"', '}');
                    FindObjectOfType<Login>().loginButton.interactable = false;
                    //FindObjectOfType<Login>().alertText.text = alert;
                    FindObjectOfType<ErrorMessageManager>().errorCanvas.gameObject.SetActive(true);
                    FindObjectOfType<ErrorMessageManager>().SetAlertType(alert);
                    return;
                }
            }
        }
        catch (WebException error)
        {
            string alert = error.Status.ToString();

            FindObjectOfType<ErrorMessageManager>().errorCanvas.gameObject.SetActive(true);
            FindObjectOfType<ErrorMessageManager>().SetAlertType(alert);

            //Game_manager.manager.alertText = error.Status.ToString();

            FindObjectOfType<Login>().username.text = "";
            FindObjectOfType<Login>().password.text = "";
            FindObjectOfType<Login>().loginButton.interactable = false;
            
        }
    }

    public void GetPlayerData()
    {
        // API request body
        string id = PlayerPrefs.GetString("playerId");
        string token = PlayerPrefs.GetString("playerToken");
        //string url = String.Format("http://localhost:5000/api/users/" + id);
        string url = String.Format("https://oppari-api.herokuapp.com/api/users/" + id);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add("Authorization", "bearer " + token);
        request.ContentType = "application/json";
        request.Method = "GET";

        // Get API request
        try
        {
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();

                string level1Name;
                string level1RecordCar;
                string level1LapTime;
                string level1GameTimes;

                string[] dataParts = result.Split(':', ','); ;

                // Level1 Statistics    SAVANNAH
                level1Name = dataParts[2].Trim('"');        
                level1RecordCar = dataParts[5].Trim('"');   
                level1LapTime = dataParts[7]; 
                level1GameTimes = dataParts[9]; 

                Debug.Log(result);
                
                PlayerPrefs.SetString("level1Name", level1Name);
                PlayerPrefs.SetString("level1RecordCar", level1RecordCar);
                PlayerPrefs.SetString("level1LapTime", level1LapTime);
                PlayerPrefs.SetString("level1GameTimes", level1GameTimes);
                PlayerPrefs.Save();

                // Level2 Statistics    MOUNTAINS
                string level2Name;
                string level2RecordCar;
                string level2LapTime;
                string level2GameTimes;

                level2Name = dataParts[14].Trim('"');
                level2RecordCar = dataParts[17].Trim('"');
                level2LapTime = dataParts[19];
                level2GameTimes = dataParts[21];

                PlayerPrefs.SetString("level2Name", level2Name);
                PlayerPrefs.SetString("level2RecordCar", level2RecordCar);
                PlayerPrefs.SetString("level2LapTime", level2LapTime);
                PlayerPrefs.SetString("level2GameTimes", level2GameTimes);
                PlayerPrefs.Save();

                // Level3 Statistics    CITY

                string level3Name;
                string level3RecordCar;
                string level3LapTime;
                string level3GameTimes;

                level3Name = dataParts[26].Trim('"');
                level3RecordCar = dataParts[29].Trim('"');
                level3LapTime = dataParts[31];
                level3GameTimes = dataParts[33];

                PlayerPrefs.SetString("level3Name", level3Name);
                PlayerPrefs.SetString("level3RecordCar", level3RecordCar);
                PlayerPrefs.SetString("level3LapTime", level3LapTime);
                PlayerPrefs.SetString("level3GameTimes", level3GameTimes);
                PlayerPrefs.Save();
            }
        }
        catch (WebException error)
        {
            string alert = error.Status.ToString();
            Debug.Log(error.Status);
            //FindObjectOfType<ErrorMessageManager>().errorCanvas.gameObject.SetActive(true);
            //FindObjectOfType<ErrorMessageManager>().SetAlertType(alert);
        }
    }

    public void UpdatePlayerData()
    {
        if(Game_manager.manager.currentLevel.level == "Savannah")
        {
            // API request body
            string id = PlayerPrefs.GetString("playerId");
            string token = PlayerPrefs.GetString("playerToken");

            string level1Name = PlayerPrefs.GetString("level1Name");
            string level1GameTimes = PlayerPrefs.GetString("level1GameTimes");
            string level1LapTime = PlayerPrefs.GetString("level1LapTime");
            string level1RecordCar = PlayerPrefs.GetString("level1RecordCar");

            //string url = String.Format("http://localhost:5000/api/users/update/" + id);
            string url = String.Format("https://oppari-api.herokuapp.com/api/users/update/" + id);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", "bearer " + token);
            request.ContentType = "application/json";
            request.Method = "PUT";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "{\"track1Stats\":{\"name\":\"" + level1Name + "\",\"details\":{\"car\":\"" + level1RecordCar + "\",\"lapTime\":\"" + level1LapTime + "\",\"gameTimes\":\"" + level1GameTimes + "\"}}}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                    Debug.Log(json);
                }
            }
            catch(WebException error)
            {
                Debug.Log(error.Status);
            }

            //Get API response
            try
            {
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Debug.Log(result);
                }
            }
            catch (WebException error)
            {
                Debug.Log(error.Status);
                Game_manager.manager.alertText = error.Status.ToString();
            }
        }

        else if(Game_manager.manager.currentLevel.level == "Mountains")
        {
            // API request body
            string id = PlayerPrefs.GetString("playerId");
            string token = PlayerPrefs.GetString("playerToken");

            string level2Name = PlayerPrefs.GetString("level2Name");
            string level2GameTimes = PlayerPrefs.GetString("level2GameTimes");
            string level2LapTime = PlayerPrefs.GetString("level2LapTime");
            string level2RecordCar = PlayerPrefs.GetString("level2RecordCar");

            //string url = String.Format("http://localhost:5000/api/users/update/" + id);
            string url = String.Format("https://oppari-api.herokuapp.com/api/users/update/" + id);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", "bearer " + token);
            request.ContentType = "application/json";
            request.Method = "PUT";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "{\"track2Stats\":{\"name\":\"" + level2Name + "\",\"details\":{\"car\":\"" + level2RecordCar + "\",\"lapTime\":\"" + level2LapTime + "\",\"gameTimes\":\"" + level2GameTimes + "\"}}}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                    Debug.Log(json);
                }
            }
            catch(WebException error)
            {
                Debug.Log(error.Status);
            }

            //Get API response
            try
            {
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Debug.Log(result);
                }
            }
            catch (WebException error)
            {
                Debug.Log(error.Status);
                Game_manager.manager.alertText = error.Status.ToString();
            }
        }

        else if(Game_manager.manager.currentLevel.level == "City")
        {
            // API request body
            string id = PlayerPrefs.GetString("playerId");
            string token = PlayerPrefs.GetString("playerToken");

            string level3Name = PlayerPrefs.GetString("level3Name");
            string level3GameTimes = PlayerPrefs.GetString("level3GameTimes");
            string level3LapTime = PlayerPrefs.GetString("level3LapTime");
            string level3RecordCar = PlayerPrefs.GetString("level3RecordCar");

            //string url = String.Format("http://localhost:5000/api/users/update/" + id);
            string url = String.Format("https://oppari-api.herokuapp.com/api/users/update/" + id);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", "bearer " + token);
            request.ContentType = "application/json";
            request.Method = "PUT";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "{\"track3Stats\":{\"name\":\"" + level3Name + "\",\"details\":{\"car\":\"" + level3RecordCar + "\",\"lapTime\":\"" + level3LapTime + "\",\"gameTimes\":\"" + level3GameTimes + "\"}}}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                    Debug.Log(json);
                }
            }
            catch (WebException error)
            {
                Debug.Log(error.Status);
            }
            
            //Get API response
            try
            {
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Debug.Log(result);
                }
            }

            catch (WebException error)
            {
                Debug.Log(error.Status);
                Game_manager.manager.alertText = error.Status.ToString();
            }
        }
    }
}
