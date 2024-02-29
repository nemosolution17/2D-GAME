using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controls the DeathUI
public class Death : MonoBehaviour
{
    public GameObject DeathUI; // Reference to the DeathUI
  
    // Start is called before the first frame update
    void Start()
    {
        DeathUI.SetActive(false); //Toggle DeathUI
    }

    // Called by PlayerController script when health is 0. Displays the DeathUI
    public void PlayerDeath()
    {
        // Turn off all UI except for DeathUI
        foreach (Transform i in DeathUI.transform.parent)
        {
            i.gameObject.SetActive(false);
        }
        DeathUI.SetActive(true);


    }

    // Returns the player to the Level Select Scene
    public void LevelSelect()
    {
        SceneManager.LoadScene(0);
    }

    // Restarts the current level.
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
