using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject trap;
    public float delay;
    private Collider2D trigger;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<Collider2D>();
        trigger.isTrigger = true;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            Invoke("CallTrap", delay);
        }
    }

    private void CallTrap()
    {
        trap.GetComponent<FallingTrap>().Fall();
    }
}
