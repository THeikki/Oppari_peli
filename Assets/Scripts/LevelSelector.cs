using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public GameObject prefab;
    public Button button;
    public Text levelName;
    public Image levelImage;

    void Start()
    {
        InstantiateLevels();
    }

    public void InstantiateLevels()
    {
        foreach(Level l in Game_manager.manager.levels)
        {
            GameObject option = Instantiate(prefab, transform);


            levelName = option.transform.GetChild(0).GetComponent<Text>();
            levelName.text = l.level;

            levelImage = option.transform.GetChild(1).GetComponent<Image>();
            levelImage.sprite = l.image;

            button = option.transform.GetChild(2).GetComponent<Button>(); ;
            button.onClick.AddListener(() =>
            {
                Game_manager.manager.SetLevel(l);
            });
        }
    }
}
