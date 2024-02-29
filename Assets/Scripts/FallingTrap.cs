using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    private Vector2 startPos;
    private Rigidbody2D rb;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fall()
    {
        rb.isKinematic = false;
        Invoke("ResetSelf",lifeTime);
    }

    void ResetSelf()
    {
        rb.isKinematic = true;
        rb.velocity = new Vector2(0, 0);
        transform.position = startPos;
    }
}
