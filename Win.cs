using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D owo) // collision
    {
        if (owo.gameObject.tag == "player") // collision with player
        {
        SceneManager.LoadScene("Win"); // load win scene
        }
    }
}
