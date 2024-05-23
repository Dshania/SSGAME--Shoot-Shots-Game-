using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform orientation;

    float hInput;
    float vInput;

    Vector3 moveDirection;
    Rigidbody rb;

    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public float airMultiplier;

    /*public float sprintSpeed;
    public float walkSpeed;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting
    }*/
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation= true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
        SpeedControl();

        /*      if (Input.GetKey(KeyCode.LeftShift))
              {
                  state = MovementState.sprinting;
                  moveSpeed = sprintSpeed;
              }
              else
              {
                  state = MovementState.walking;
                  moveSpeed = walkSpeed;
              }*/

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    private void MyInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * vInput + orientation.right * hInput;
       // Debug.Log(moveDirection);
       if(grounded)
        rb.AddForce(moveDirection.normalized*moveSpeed*10f,ForceMode.Force);
       else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }
    
  private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude> moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }
    }
}
