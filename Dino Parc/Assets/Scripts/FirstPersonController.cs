using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// can handle basic collisions and physics for the player without the need for a rigidbody
[RequireComponent(typeof(CharacterController))] 

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpPower;

    [SerializeField] private float gravity;  // gravity force applied whenn the player is jumping
    [SerializeField] private float mouseSpeed;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    private bool moving = false;
    private bool canMove = true;
    private CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // lock the cursor in the center of the screen
        Cursor.visible = false; // hide the cursor
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float cursorSpeedX = canMove ?movementSpeed * Input.GetAxis("Vertical") : 0;
        float cursorSpeedY = canMove ? movementSpeed * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * cursorSpeedX) + (right * cursorSpeedY);

        moving = (Mathf.Abs(cursorSpeedX) > 0 || Mathf.Abs(cursorSpeedY) > 0) && characterController.isGrounded;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            moving = false;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * mouseSpeed;
            rotationX = Mathf.Clamp(rotationX, -45f, 45f); // the player can't look up or down more than 45 degrees
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSpeed, 0);
        }


    }

    public bool isMoving()
    {
        return moving;
    }

    public bool isGrounded()
    {
        return characterController.isGrounded;
    }


}