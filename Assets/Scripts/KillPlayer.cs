using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Kills the player and calls the LevelManager script to respawn the player at the last checkpoint
// Currently used on the collider below the map. May or may not be used for enemies in the future depending on whether the enemy kills or damages the player
public class KillPlayer : MonoBehaviour
{
    //Stores the reference to the levelManager
    public LevelManager levelManager;
    // Start is called before the first frame update
    private PlayerController player;
    public Score score; // References Score script
    private bool scoreLost;
    void Start()
    {
        //Finds the LevelManager
        levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        score = FindObjectOfType<Score>(); // Gets Score script
        scoreLost = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreLost = false;
    }
    // When the player touches the collider box, levelManager is called to respawn the player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            player.setHealth(); //Lowers the players health by one

            // Change Score appropriately
            if (scoreLost) return;
            scoreLost = true;
            if (score.score >= 500)
            {
                score.score -= 500;
            }
            else
            {
                score.score = 0;
            }
            levelManager.respawnPlayer();
        }
    }
}
