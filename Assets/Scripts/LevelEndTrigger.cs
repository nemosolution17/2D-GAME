using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Placed on Sprite to end level
public class LevelEndTrigger : MonoBehaviour
{
    public EndOfLevel endOfLevel; // Holds reference to EndOfLevel script
    //bool levelEnded = false;
    void Start()
    {
        // Assigns the reference to the EndOfLevel
        endOfLevel = FindObjectOfType<EndOfLevel>();
        //levelEnded = false;
    }
    void Update()
    {
        //levelEnded = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player touches the sprite, end the level
        if (other.name == "Player")
        {
            //if (levelEnded) return;
            endOfLevel.EndLevel();
            //Rigidbody rigid = other.GetComponent<Rigidbody>();
            //rigid.constraints = RigidbodyConstraints.FreezePosition;
            //levelEnded = true; 
        }
    }
}
