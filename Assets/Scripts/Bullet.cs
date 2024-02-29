using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 20f;
    public Rigidbody2D bulletBody;
    public int damage = 40;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        bulletBody.velocity = transform.right * bulletSpeed; //sends bullet at a set direction and speed
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /*
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            //enemy.TakeDamage(damage);
        }
        */

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
