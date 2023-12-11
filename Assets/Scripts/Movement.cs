using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    public float acceleration;
    public float maxSpeed = 6f;
    public float linearDrag;
    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        //Provides values (-1 / 1) for moving in axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Adds force to the player using the direction and acceleration
        rb.AddForce(movement * acceleration);

        //Limits the maximum speed the player can reach
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) > maxSpeed)
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * maxSpeed);

        LinearDrag();
    }

    private void LinearDrag()
    {
        //Changes the amount of drag depending on the action
        //If the player is moving slowly or changing direction, the drag is set to linear drag, if not it is set to 0
        if (Mathf.Abs(movement.magnitude) < 0.4f)
        {
            rb.drag = linearDrag;
        }
        else
        {
            rb.drag = 1f;
        }
    }
}
