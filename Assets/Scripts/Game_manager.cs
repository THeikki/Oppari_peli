using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_manager : MonoBehaviour
{
    public static Game_manager manager;
    public Car[] cars;
    public Car currentCar;
    public Level[] levels;
    public Obstacle[] obsctacles;
    public Level currentLevel;
    public string alertText;
   
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetCar(Car car)
    {
        currentCar = car;
        FindObjectOfType<MainMenu>().selectedCar.text = "Selected car: " + Game_manager.manager.currentCar.carName.ToString();
    }

    public void SetLevel(Level level)
    {
        currentLevel = level;
        FindObjectOfType<MainMenu>().selectedLevel.text = "Selected level: " + Game_manager.manager.currentLevel.level.ToString();
    }

}