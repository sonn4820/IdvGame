using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float moveSpeed = 4f;
    public Transform target; // Drop the player in the inspector of the camera
    public float cameraDistance = 75.0f;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance); // change the distance between camera and player
    }
    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        
    }
   
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(target.position.x + 5f, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
    


}
