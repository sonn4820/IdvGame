using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject orbPrefab; // var to hold prefab for instantiating orbs

    public float health = 10f; // initialize hp = 2
    public float speed = 4f; // set up speed of enemy

    float chanceDirectionChange = 0.04f; // how likely ship will change direction
    public float secsBetweenLaunch = 2f; // rate that we generate orbs from the enemy

    public Animator animator;
    public float delay = 0f;

    public AudioSource aaa;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchOrb", 2f, secsBetweenLaunch);  //calls a function every x secs 2f from start of game
        orbPrefab.gameObject.SetActive(false);
        aaa.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        orbPrefab.gameObject.SetActive(true);

        if (health <= 0f)
        {
            animator.SetFloat("HP", health);
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
            CancelInvoke("LaunchOrb");
        }

        Vector3 Ypos = transform.position; // create a var to hold current position
        Ypos.y += speed * Time.deltaTime; // sets the Ypos of our ship to the speed var * sec since last frame
        transform.position = Ypos;
        
        if (Ypos.y < -3.6f)
        {
            speed = Mathf.Abs(speed);// if the enenmy pos is less than -1.5 set speed to a pos number
        }
        else if (Ypos.y > -1.3f)
        {

            speed = -Mathf.Abs(speed);  // if the enemy pos x is greater than 0.75 reverse speed
        }
        

    }
    
    void FixedUpdate()
    {

        if (Random.value < chanceDirectionChange)
        {  // change direction at a random interval
            speed *= -1;
        }

    }

    void LaunchOrb()
    {
        Vector2 pos = new Vector2(transform.position.x, Random.Range(-3.2f, -1f));
        Instantiate(orbPrefab, pos, transform.rotation);
    }




    void OnTriggerEnter2D(Collider2D shot)
    {

        if (shot.gameObject.tag == "arrow")
        { 
        health -= 1f; // lose health when collide with arrow
            aaa.Play();
        }

    }

}
