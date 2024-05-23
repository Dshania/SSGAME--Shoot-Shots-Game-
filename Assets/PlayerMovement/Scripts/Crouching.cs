using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    Rigidbody rb;

    Movement movement;
    Sprint walkSpeed;

    public MovementState state;
    public enum MovementState
    {
        walking,
        crouching
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        movement = GetComponent<Movement>();
        walkSpeed = GetComponent<Sprint>();
        startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x,startYScale, transform.localScale.z);     
        }

        if (Input.GetKey(KeyCode.C))
        {
            state = MovementState.crouching;
            movement.moveSpeed = crouchSpeed;
        }
        else
        {
            state = MovementState.walking;
           // movement.moveSpeed = Sprint.walkSpeed;
        }

    }
}
