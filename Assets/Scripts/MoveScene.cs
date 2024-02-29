using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Moves the player to a new scene. Specify name of level (scene) in unity.
public class MoveScene : MonoBehaviour
{
    public string newLevel;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            SceneManager.LoadScene(newLevel);
        }
    }
}
