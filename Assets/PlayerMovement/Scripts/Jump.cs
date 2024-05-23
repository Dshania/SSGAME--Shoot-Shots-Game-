using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    Rigidbody rb;

    public int maxJumpCount;
    private int jumpsRemaining = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        jumpsRemaining = maxJumpCount;
        jumpCooldown = 2;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& jumpsRemaining > 0 /*&& readyToJump && grounded*/)
        {
            readyToJump = false;
            jumpsRemaining -=1;
            JumpUp();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void JumpUp()
    {
        rb.velocity = new Vector3(rb.velocity.x,0f,rb.velocity.z);
        rb.AddForce(transform.up *jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
        maxJumpCount =2;
        jumpsRemaining = 2;
    }
}
