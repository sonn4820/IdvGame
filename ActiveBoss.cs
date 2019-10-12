using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActiveBoss : MonoBehaviour
{
    public GameObject Boss;  // reference to portal
    public GameObject lastminion; // referece to enemy object
   
    // Start is called before the first frame update
    void Start()
    {
        Boss.gameObject.SetActive(false); // hide the portal
    }

    // Update is called once per frame
    void Update()
    {
        if (lastminion == null)
        {  // see if the enemy has been destroyed
            Boss.gameObject.SetActive(true); // show the portal
        }
    }
}
