using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController2D : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed; //How fast the player moves side to side
    public float jumpForce; //How high the player jumps
    public bool isGrounded; //Is the player on the ground T/F?
    public int bottomBound = -4;
    public int score = 0; // <--- add this

    // Animator reference
    public Animator animator;

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
        // use Rigidbody2D.velocity (rig.linearVelocity may not exist)
        rig.linearVelocity = new Vector2(moveInput * moveSpeed, rig.linearVelocity.y);

        // Update moving bool (tweak threshold if you need deadzone)
        if (animator != null)
            animator.SetBool("Running", Mathf.Abs(moveInput) > 0.1f);
    }

    void Update()
    {
        //If we press the jump button and we are grounded then jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            // set jumping before applying force so animation responds immediately
            if (animator != null) animator.SetBool("Jumping", true);

            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Makes the player jump with all of the force applied
        }

        //If the player falls out of the level, reset the scene
        if(transform.position.y < bottomBound)
        {
            GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // If the contact normal is mostly upwards (within 45 degrees)
            if (Vector2.Angle(contact.normal, Vector2.up) < 45f)
            {
                isGrounded = true;
                // landed -> clear jumping flag
                if (animator != null) animator.SetBool("Jumping", false);
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Optional: if we leave any collider, we may not be grounded anymore
        // You can add checks to ensure it was a ground layer
        isGrounded = false;
        if (animator != null) animator.SetBool("Jumping", true);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
