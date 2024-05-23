using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    public Transform orientation;
    public Rigidbody rb;
    public LayerMask whatIsWall;

    public float climbSpeed;
    public float maxClimbTime;
    private float climbTimer;
    private bool climbing;

    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontwallHit;
    private bool wallFront;

    bool grounded;
    public float playerHeight;
    public LayerMask whatIsGround;

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        WallCheck();
        StateMachine();

        if (climbing) ClimbingMovement();

    }

    private void StateMachine()
    {
        // climbing state
        if (wallFront && Input.GetKey(KeyCode.X) && wallLookAngle < maxWallLookAngle)
        {
            if (!climbing && climbTimer > 0) StartClimbing();
            if (climbTimer > 0) climbTimer -= Time.deltaTime;
            if (climbTimer < 0) StopClimbing();
        }
        else
        {
            if (climbing) StopClimbing();
        }
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontwallHit, detectionLength, whatIsWall);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontwallHit.normal);

        if (grounded)
        {
            climbTimer = maxClimbTime;
        }
    }
    
    private void StartClimbing()
    {
        climbing = true;
    }

    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    private void StopClimbing()
    {
        climbing = false;
    }

}
