using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float HP = 30f;
    public Text HPbar;
    public GameObject panel;
    public AudioSource ouch;
    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(false);
        ouch = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
            panel.gameObject.SetActive(true);
        }
        HPbar.text = "HP: " + HP;
    }
    
    private void OnTriggerEnter2D(Collider2D uwu)
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
