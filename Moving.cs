
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    public float speed = 3f; // set up speed
    public Animator animator;
    public float moveHorizontal; // call new float for horizontal movement
    public float moveVertical; // call new float for vertical movement
    private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     void Flip(float moveHorizontal)
    {
        if (moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
       
        }
    }
    void FixedUpdate()
    {

        moveHorizontal = Input.GetAxis("Horizontal") * speed; // move hor
        
        moveVertical = Input.GetAxis("Vertical") * speed; // move ver

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        Flip(moveHorizontal);

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal, moveVertical); // get rigidbody for player
        if (transform.position.y > -1.3f)
        {
            transform.position = new Vector2(transform.position.x, -1.3f);
        }
        if (transform.position.y < -3.6f)
        {
            transform.position = new Vector2(transform.position.x, -3.6f);
        }
        if (transform.position.x < -6f)
        {
            transform.position = new Vector2(-6f, transform.position.y);
        }
        
    }
    
}
