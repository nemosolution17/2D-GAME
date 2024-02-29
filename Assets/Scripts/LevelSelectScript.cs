using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controls the Level Select UI
public class LevelSelectScript : MonoBehaviour
{
    public Game_Manager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<Game_Manager>();
    }
    // Loads the level that the player selects
    public void LevelSelect(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void MainMenu()
    {
        Destroy(GameObject.Find("GameM"));
        //Destroy(GameObject.Find("Main Camera"));
        SceneManager.LoadScene(3);
    }
}
