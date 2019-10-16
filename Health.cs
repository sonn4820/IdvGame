using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float HP = 25f; // set HP
    public Text HPbar; // place for text
    public GameObject panel; //place for panel
    public AudioSource ouch; // place of audio
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(false); // hide panel
        ouch = GetComponent<AudioSource>(); // get audio
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) // if hp <0
        {
            Destroy(this.gameObject); // die
            panel.gameObject.SetActive(true); // show panel
        }
        else if( player != null)
        {
            panel.gameObject.SetActive(false); // hide panel
        }
        HPbar.text = "HP: " + HP; // show hp on screen
    }
    
    private void OnTriggerEnter2D(Collider2D uwu) // lose hp if collided with demons
    {
        if (uwu.gameObject.tag == "g")
        {
            HP -= 1;
            ouch.Play();
        }
        if (uwu.gameObject.tag == "s")
        {
            HP -= 5;
            ouch.Play();
        }
        if (uwu.gameObject.tag == "m")
        {
            HP -= 3;
            ouch.Play();
        }
        if (uwu.gameObject.tag == "b")
        {
            HP -= 30;
            ouch.Play();
        }
        
    }
}
