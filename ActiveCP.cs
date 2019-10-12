using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActiveCP : MonoBehaviour
{
    public GameObject CP;  // reference to portal
    public GameObject boss; // referece to enemy object

    // Start is called before the first frame update
    void Start()
    {
        CP.gameObject.SetActive(false); // hide the portal
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {  // see if the enemy has been destroyed
            CP.gameObject.SetActive(true); // show the portal
        }
    }
}