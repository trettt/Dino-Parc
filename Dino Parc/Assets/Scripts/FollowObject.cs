using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    private float sensitivity = 2f;
    private float verticalRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = objectToFollow.position + offset;

       
        float horizontalRotation = objectToFollow.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

       
        verticalRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
