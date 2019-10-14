using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skeleton : MonoBehaviour
{
    public GameObject Player;
    // every code which isn't commented is the same with the ghost script

    public float speed = 0f;
    public float health = 5f;
    public float Dis; // set up float distance
    public Animator animator;
    public AudioSource o2;


    public float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        o2.GetComponent<AudioSource>();
    }

    void OnBecameVisible()
    {
  
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

        if (Vector2.Distance(transform.position, Player.transform.position) > Dis) // this code is not working at all
        { 
            speed = 0f;
            animator.SetFloat("Speed", speed);
        }
        if (Vector2.Distance(transform.position, Player.transform.position) < Dis) // get close to the player if he crosses the safe distance
        {
            speed = 4.5f;
            animator.SetFloat("Speed", speed);
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            
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
            o2.Play();
            health -= 1;
            

        }
        if (collision.gameObject.tag == "player")
        {
            o2.Play();
            health -= 5;
            animator.SetFloat("HP", health);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
            
        }
    }
}
