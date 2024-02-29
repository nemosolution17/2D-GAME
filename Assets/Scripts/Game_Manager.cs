using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject StartUI;
    public InputField Name;
    public string PlayerName;
    // Start is called before the first frame update


    void Start()
    {
        Name.characterLimit = 10;
        DontDestroyOnLoad(gameObject);
        PlayerName = "";
    }


    public void NameEntered()
    {
        PlayerName = Name.text;
        SceneManager.LoadScene(0);
    }

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene(5);
    }
    public string GetName()
    {
        return this.PlayerName;
    }
}

