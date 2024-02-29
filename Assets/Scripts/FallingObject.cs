using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float duration = 1f; //Amount of time before the object falls
    public float lifeTime = 5f; //Amount of time before the object destroys itself

    private Rigidbody2D rb; //The rigidbody used to make the object fall
    private Vector3 startingPosition; //The starting position of the object

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody2D>() != null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            rb = this.gameObject.AddComponent<Rigidbody2D>();
            rb.isKinematic = true;
            rb.freezeRotation = true;
        }

        startingPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("DropObject", duration);
            Invoke("ResetSelf", lifeTime);
        }
    }

    void DropObject()
    {
        rb.isKinematic = false;
    }

    void ResetSelf()
    {
        rb.isKinematic = true;
        transform.position = startingPosition;
        rb.velocity = new Vector2(0, 0);
    }

}
