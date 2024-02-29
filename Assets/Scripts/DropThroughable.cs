﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropThroughable : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") >= 0)
        {
            waitTime = 0.5f;
            effector.rotationalOffset = 0f;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
