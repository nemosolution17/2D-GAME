using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When the player touches the collider the Timer is stopped
public class StopTimer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Player").SendMessage("Finish");
    }
}
