using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController2D : MonoBehaviour
{
    //Value Types
    [Header("Player Settings")]
    public float moveSpeed; //How fast the player moves side to side
    public float jumpForce; //How high the player jumps
    public bool isGrounded; //Is the player on the ground T/F?
    public int bottomBound = -4;
    [Header("Score")]
    public int score; //Store the score value

    //Reference Types
    public Rigidbody2D rig; //Rigidbody component reference
    public TextMeshProUGUI scoreText; //Reference to the score text UI element

    //Increase the score and Update the score text UI
    public void AddScore(int amount)
    {
        //Add to score
        score += amount;
        //Update score text UI
        scoreText.text = "Score: " + score;
    }
    void FixedUpdate()
    {
        //Gather Inputs
        float moveInput = Input.GetAxis("Horizontal");
        //Make the player move side to side
        rig.linearVelocity = new Vector2(moveInput * moveSpeed, rig.linearVelocity.y);
    }

    void Update()
    {
        //If we press the jump button and we are grounded then jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Makes the player jump with all of the force applied
        }

        //If the player falls out of the level, reset the scene
        if(transform.position.y < bottomBound)
        {
            GameOver();
        }

    }
    void OnCollisionEnter2d(Collision2D collision)
    {
        //If player collides with the ground, set isGrounded to true
        if (collision.GetContact(0).normal == Vector2.up)
        {
            isGrounded = true;
        }
    }
        public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
