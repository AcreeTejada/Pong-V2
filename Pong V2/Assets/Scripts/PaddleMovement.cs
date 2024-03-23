using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Variables for the code
    public float speed = 10f;
    public float yBorder = 5.1f;
    private Rigidbody2D rb2d;

    // Determine if this is the left or right paddle
    public bool isLeftPaddle;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var velocity = rb2d.velocity; // Create and declare variable for velocity

        // Control the paddle based on whether it's left or right
        if (isLeftPaddle)
        {
            if (Input.GetKey(KeyCode.W) && transform.position.y < yBorder)
            {
                velocity.y = speed;
            }
            else if (Input.GetKey(KeyCode.S) && transform.position.y > -yBorder)
            {
                velocity.y = -speed;
            }
            else
            {
                velocity.y = 0;
            }
        }
        else // Right Paddle
        {
            if (Input.GetKey(KeyCode.O) && transform.position.y < yBorder)
            {
                velocity.y = speed;
            }
            else if (Input.GetKey(KeyCode.L) && transform.position.y > -yBorder)
            {
                velocity.y = -speed;
            }
            else
            {
                velocity.y = 0;
            }
        }

        rb2d.velocity = velocity;
    }
}