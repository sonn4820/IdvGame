using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Maggot : MonoBehaviour
{
    public GameObject Player; // every code which isn't commented is the same with the ghost script

    public float speed = 5f;
    public float health = 3f;
    public float Dis; // set up distance float
    public Animator animator;
    bool atk; // set up attack bool for the animation
    private Vector3 offset;   // set up distance vector 3
    public AudioSource o1;
    public float delay = 0f;
    // Start is called before the first frame update

    void Start()
    {
        offset = transform.position - Player.transform.position; // define the offset distance
        animator = gameObject.GetComponent<Animator>(); // get animation
        atk = false; // set the bool is false
        o1.GetComponent<AudioSource>();
    }


    // Update is called once per frame

    void Update()
    {
        
        if (health <= 0)
        {
            speed = 0f;
            animator.SetFloat("HP", health);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }

        if (atk == true) 
        {
            animator.SetBool("atk", atk);
        }
        if (atk == false)
        {
            animator.SetBool("atk", atk);
        }

        if (Vector2.Distance(transform.position, Player.transform.position) < Dis) // appoarch the player 
        {
            speed = 12f;
            animator.SetFloat("Speed", speed);
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

        }
        if (Vector2.Distance(transform.position, Player.transform.position) < 2f) // when it gets close the player, it will stick to the player
        {
            transform.position = Player.transform.position + 0.03f * offset; // stick distance
            atk = true; // attack the player and play animation

        }

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

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            health -= 1;
            o1.Play();
        }
        
        
    }
}