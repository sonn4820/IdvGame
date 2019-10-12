using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howtoplay : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        panel.gameObject.SetActive(true);
    }
}
