using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Timer timer; // Reference to my Timer script
    public bool xMove = true;
    public bool yMove = true;
    public float xSpeed = 0.095f;
    public float ySpeed = 0.095f;
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

    // Update is called once per frame
    void Update()
    {
        // Check if the timer has run out in Level 2
        if (timer != null && !timer.timerIsRunning && SceneManager.GetActiveScene().name == "Level2")
        {
            // Load Scene 3 (Level 3) when the timer runs out in Level 2
            SceneManager.LoadScene("Level 3");
        }
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