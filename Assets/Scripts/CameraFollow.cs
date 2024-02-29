using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera Follows the player
public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}
