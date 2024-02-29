using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controls the Heart display
public class HUD : MonoBehaviour
{
    public Image[] hearts; // Stores the heart images
    public Sprite fullHeart; // Reference to the fullHeart image
    public Sprite emptyHeart; // Reference to the emptyHeart image
    private PlayerController player; // Reference to the PlayerController script
    private int numOfHearts = 5; // Initial number of hearts to be displayed at the beginning of the level
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // Get the PlayerController script
    }

    void Update()
    {
        // Sets players health to the number of lives they have left
        if (player.curHealth > numOfHearts)
        {
            player.curHealth = numOfHearts;
        }

        // Sets the hearts displayed on the screen
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.curHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
