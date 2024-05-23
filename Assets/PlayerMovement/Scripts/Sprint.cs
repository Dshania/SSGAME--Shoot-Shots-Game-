using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
  //  public float moveSpeed;
    public float sprintSpeed;
    public float walkSpeed;
    Movement movement;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting
    }
    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            state = MovementState.sprinting;
            movement.moveSpeed = sprintSpeed;
        }
        else
        {
            state = MovementState.walking;
            movement.moveSpeed = walkSpeed;
        }
    }
}
