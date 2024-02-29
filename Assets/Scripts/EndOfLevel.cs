using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

//Responsible for handling end of level mechanics
public class EndOfLevel : MonoBehaviour
{
    public GameObject EndMenuUI; // References the EndMenuUI
    public PlayerController player; // References the PlayerController script
    public Text timeText; // References the timer text field on the EndMenuUI
    public Text scoreText;
    public Timer timer; // References the Timer script
    public Score score;
    public Text congratulations;
    public Game_Manager gameManager;
    public Weapon weapon;
    private bool levelEnded;

    // Start is called before the first frame update
    void Start()
    {
        EndMenuUI.SetActive(false); //Toggle EndMenuUI
        player = FindObjectOfType<PlayerController>(); //Assigns the PlayerController script
        timer = FindObjectOfType<Timer>();//Assigns the Timer script
        score = FindObjectOfType<Score>();
        gameManager = FindObjectOfType<Game_Manager>();
        weapon = FindObjectOfType<Weapon>();
        levelEnded = false;
    }

    // Called by LevelEndTrigger to end the level
    public void EndLevel()
    {
        // Turns off all UI except for the EndMenuUI
        player.pausePlayer = true;
        weapon.pausePlayer = true;
        foreach (Transform i in EndMenuUI.transform.parent)
        {
            i.gameObject.SetActive(false);
        }
        EndMenuUI.SetActive(true);

        congratulations.text = "Congratulations " + gameManager.GetName();
        //Get timer information to display on EndMenuUI
        float t = Time.time - timer.GetStartTime();
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timeText.text = "Completed In: " + minutes + ":" + seconds;

        //Convert the time into an int
        //Substract 1 point from the total score for each second that the player was in the level.
        score.score -= Int32.Parse(minutes) * 60 + (int)Convert.ToDouble(seconds);
        if (score.score < 0)
        {
            score.score = 0;
        }
        scoreText.text = ("Score: " + score.score);

        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
        if (levelEnded) return;
        var Line = gameManager.GetName() + " " + (score.score  - (Int32.Parse(minutes) * 60 + (int)Convert.ToDouble(seconds))) + " " + t;
        File.AppendAllText(@"C:\Users\1997g\Desktop\Master\Leaderboard\" + currentSceneName+ ".txt", Line + Environment.NewLine);
        //File.AppendAllText(@"C:\Users\1997g\Desktop\Master\Leaderboard\Level-1.txt", Line + Environment.NewLine);
        levelEnded = true;
    }


    //Navigate to the Level Select scene
    public void LevelSelect()
    {
        SceneManager.LoadScene(0);
    }

    //Quits the game. Only works in the compiled version. Does not quit the Unity Editor.
    public void Quit()
    {
        Application.Quit();
    }

    // Restarts the current level.
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // Takes the player to the next level
    public void NextLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
