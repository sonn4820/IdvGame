using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 20f; // set up speed for the orb
    public Animator animator; // get animator
    public float delay = 0f; // delay time for death animation
    public Rigidbody2D rb; // get the rigidboy of the arrow
    bool hit; // call bool hit
    public AudioSource z1; // get the audio
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; // set up the formula of arrows' speed
        hit = false; // set hit is false
        z1.GetComponent<AudioSource>(); // get audio source
    }

    // Update is called once per frame

    void Update()
    {
        if (hit == true)
        {
            animator.SetBool("hit", hit); // play death animation
        }
        if (hit == false)
        {
            animator.SetBool("hit", hit); // otherwise don't
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject); // destroy when it goes off the screen
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player") // collide with the player
        {
            z1.Play(); // play sound
            hit = true; // hit = true
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); // destroy after the delay time
        }
        if (collision.gameObject.tag == "arrow") // same as above
        {
            z1.Play();
            hit = true;
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }

}
