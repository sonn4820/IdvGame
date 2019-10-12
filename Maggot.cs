using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Maggot : MonoBehaviour
{
    public GameObject Player;

    public float speed = 5f;
    public float health = 3f;
    public float Dis;
    public Animator animator;
    bool atk;
    private Vector3 offset;   // private var that determines the camera distance from the play
    public AudioSource o1;
    public float delay = 0f;
    // Start is called before the first frame update

    void Start()
    {
        offset = transform.position - Player.transform.position;
        animator = gameObject.GetComponent<Animator>();
        atk = false;
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

        if (Vector2.Distance(transform.position, Player.transform.position) < Dis)
        {
            speed = 12f;
            animator.SetFloat("Speed", speed);
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

        }
        if (Vector2.Distance(transform.position, Player.transform.position) < 2f)
        {
            transform.position = Player.transform.position + 0.03f * offset;
            atk = true;

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