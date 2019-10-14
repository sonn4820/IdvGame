using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : MonoBehaviour
{
    public GameObject Player; // get the player
    public float speed = 1f; // set up speed
    public float health = 1f; // set up health
    public Animator animator; // get animator
    public float delay = 0f; // set delay after death
    public AudioSource o1; // get audio source
    // Start is called before the first frame update
    void Start()
    {
        o1.GetComponent<AudioSource>(); // play the audio source
    }
    
    // Update is called once per frame

    void Update()
    {
       

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime); // moving toward the player

        if (Player.transform.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Player.transform.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (health <= 0) // if hp is below 0, destroy and play death animation
        {
            speed = 0f;
            animator.SetFloat("HP", health);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player") // destroy when collide the player
        {
            health -= 1;
            o1.Play();
            animator.SetFloat("HP", health);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
        if (collision.gameObject.tag == "arrow") // lose hp when get hit by arows
        {
            health -= 1;
            o1.Play();

        }
    }
    
}
