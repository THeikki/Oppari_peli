using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelector : MonoBehaviour
{
    public GameObject prefab;
    public Button button;
    public Text carName;
    public Text carSpeed;
    public Text carTurning;
    public Text carInfo;
    public Image carImage;
    
    private void Start()
    {
        InstantiateCars();  
    }

    public void InstantiateCars()
    {
        foreach (Car c in Game_manager.manager.cars)
        {
            GameObject option = Instantiate(prefab, transform);

            carName = option.transform.GetChild(0).GetComponent<Text>();
            carName.text = c.carName;

            carSpeed = option.transform.GetChild(3).GetComponent<Text>();
            carSpeed.text = c.carSpeed;

            carTurning = option.transform.GetChild(4).GetComponent<Text>();
            carTurning.text = c.carTurning;

            carInfo = option.transform.GetChild(5).GetComponent<Text>();
            carInfo.text = c.carInfo;

            carImage = option.transform.GetChild(1).GetComponent<Image>();
            carImage.sprite = c.image;
          
            button = option.transform.GetChild(2).GetComponent<Button>(); ;
            button.onClick.AddListener(() =>
            {
                Game_manager.manager.SetCar(c);
            });
            
            //GameObject ChildGameObject1 = option.transform.GetChild(0).gameObject;
            //GameObject ChildGameObject2 = option.transform.GetChild(1).gameObject;
            //GameObject ChildGameObject3 = option.transform.GetChild(2).gameObject;
            //GameObject ChildGameObject4 = option.transform.GetChild(3).gameObject;
            //Debug.Log(ChildGameObject1);
            //Debug.Log(ChildGameObject2);
            //Debug.Log(ChildGameObject3);
            //Debug.Log(ChildGameObject4);
        }
    }

}