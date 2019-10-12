using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1f;
    public float health = 1f;
    public Animator animator;
    public float delay = 0f;
    public AudioSource o1;
    // Start is called before the first frame update
    void Start()
    {
        o1.GetComponent<AudioSource>();
    }
    
    // Update is called once per frame

    void Update()
    {
       

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

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
        if (health <= 0)
        {
            speed = 0f;
            animator.SetFloat("HP", health);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            health -= 1;
            o1.Play();
            animator.SetFloat("HP", health);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
        if (collision.gameObject.tag == "arrow")
        {
            health -= 1;
            o1.Play();

        }
    }
    
}
