using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    // Variables for the game
    public bool xMove = true;
    public bool yMove = true;
    public float xSpeed = 0.08f;
    public float ySpeed = 0.08f;
    public float xBorder = 10.1f;
    public float yBorder = 5.1f;
    int leftPlayerScore = 0;
    int rightPlayerScore = 0;
    public Text scoreTextLP;
    public Text scoreTextRP;
    
    bool ballInPlay = true;

    void Start()
    {
        LaunchBall();
    }

    void Update()
    {
        if (!ballInPlay)
            return;

        MoveBall();
        CheckBorders();
    }

    void MoveBall()
    {
        transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y + ySpeed);
    }

    void CheckBorders()
    {
        if (transform.position.x >= xBorder || transform.position.x <= -xBorder)
        {
            if (transform.position.x > 0)
                leftPlayerScore++;
            else
                rightPlayerScore++;

            UpdateScores();
            ResetBallPosition();
            ballInPlay = true; // Set ballInPlay to true before launching the ball again

            // Check if any player has reached 5 points
            if (leftPlayerScore >= 5 || rightPlayerScore >= 5)
            {
                // Load Scene 2 (Level 2)
                SceneManager.LoadScene("Level 2");
            }
            else
            {
                LaunchBall();
            }
        }

        if (transform.position.y >= yBorder || transform.position.y <= -yBorder)
        {
            ySpeed *= -1;
        }
    }

    void UpdateScores()
    {
        scoreTextLP.text = leftPlayerScore.ToString();
        scoreTextRP.text = rightPlayerScore.ToString();
    }

    void ResetBallPosition()
    {
        transform.position = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("RPlayer") || coll.collider.CompareTag("LPlayer"))
        {
            xSpeed *= -1;
        }
    }

    public void LaunchBall()
    {
        ballInPlay = true;
        xSpeed = Mathf.Abs(xSpeed); // Ensure xSpeed is positive to launch in the correct direction
    }
}