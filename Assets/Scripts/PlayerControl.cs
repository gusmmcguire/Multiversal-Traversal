using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5;
    [SerializeField] float jumpPower = 5;

    Vector2 movement;
    PlayerInput playerInput;
    Vector3 jumpForce;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        
        jumpForce = new Vector3(0, jumpPower, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rbMovement = Vector3.zero;
        if (playerInput.actions.FindAction("Movement").IsPressed())
        {
            movement = playerInput.actions.FindAction("Movement").ReadValue<Vector2>();
            rbMovement = new Vector3(movement.x, 0, movement.y);
            var rot = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
            rbMovement = rot * rbMovement;
            //gameObject.transform.forward = rbMovement.normalized;
        }

        rb.AddForce(rbMovement * playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
        rbMovement = Vector3.zero;
    }

    void OnJump()
    {
        rb.AddForce(jumpForce,ForceMode.VelocityChange);
    }
}
