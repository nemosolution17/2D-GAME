using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;
    public bool paused = false;

    // Stores the state of the Pause Menu. Active or not active. Initially set to not active.
    void Start()
    {
        PauseUI.SetActive(false);
    }

    // Pauses the game when the esc key is pressed.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        } 
    }

    // Resumes the game.
    public void Resume()
    {
        paused = false;
    }
    // Restarts the current level.
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    // Takes the player to the level select screen.
    public void LevelSelect()
    {
        SceneManager.LoadScene(0);
    }

    //Quits the game. Only works in the compiled version. Does not quit the Unity Editor.
    public void Quit()
    {
        Application.Quit();
    }

}
