using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores Player current respawn point and respawns the player
// Should only ever be used on the LevelManager Object located under Map Objects
public class LevelManager : MonoBehaviour 
{
    public GameObject currentCheckpoint; //Current Checkpoint Player will respawn at
    // To place a checkpoint, drag and drop one from the prefab folder, all attributes will be pre-applied
    private PlayerController player; //Stores The player Reference


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>(); //Finds the PlayerController script
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Respawns the player
    public void respawnPlayer()
    {
        //Moves the players position
        player.transform.position = currentCheckpoint.transform.position;
        // Sets the players velocity to 0 to avoid player glitching through ground
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
