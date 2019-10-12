
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f; // set up the speed
    public Rigidbody2D rb; // get the rigidboy of the arrow
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; // set up the formula of arrows' speed
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject); // destroy arrows when they collide to other objects

    }

}