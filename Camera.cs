using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float moveSpeed = 4f; // call speed
    public Transform target; // Drop the player in the inspector of the camera
    public float cameraDistance = 75.0f; // distance of the camera 

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance); // change the distance between camera and player
    }
    // Use this for initialization
    void Start()
    {
        
        
    }
   
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(target.position.x + 5f, transform.position.y, transform.position.z); // call new vector 3 for camera
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime); // make camera follow player
    }
    


}
