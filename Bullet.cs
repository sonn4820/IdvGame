using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Animator animator;
    public float delay = 0f;
    public Rigidbody2D rb; // get the rigidboy of the arrow
    bool hit;
    public AudioSource z1;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; // set up the formula of arrows' speed
        hit = false;
        z1.GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void Update()
    {
        if (hit == true)
        {
            animator.SetBool("hit", hit);
        }
        if (hit == false)
        {
            animator.SetBool("hit", hit);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            z1.Play();
            hit = true;
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
        if (collision.gameObject.tag == "arrow")
        {
            z1.Play();
            hit = true;
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }

}
