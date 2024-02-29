using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Holds the Score for the current level
public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = ("Score: " + score); // Display Score on screen
    }
}
