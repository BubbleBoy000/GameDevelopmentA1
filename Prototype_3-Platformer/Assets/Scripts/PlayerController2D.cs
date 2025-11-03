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
    public string runningParam = "Running";
    public string jumpingParam = "Jumping";

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
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>(); // auto-assign if Animator is on same GameObject

        // auto-assign common references if not set in Inspector
        if (rig == null) rig = GetComponent<Rigidbody2D>();
        if (scoreText == null) scoreText = FindObjectOfType<TMPro.TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        //Gather Inputs
        float moveInput = Input.GetAxis("Horizontal");

        //Make the player move side to side
        // use velocity (Rigidbody2D.velocity), not linearVelocity
        if (rig != null)
            rig.linearVelocity = new Vector2(moveInput * moveSpeed, rig.linearVelocity.y);

        // Update running bool (tweak threshold if you need deadzone)
        if (animator != null)
            animator.SetBool(runningParam, Mathf.Abs(moveInput) > 0.1f);
    }

    void Update()
    {
        //If we press the jump button and we are grounded then jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            // set jumping trigger so animation responds immediately
            if (animator != null) animator.SetTrigger(jumpingParam);

            if (rig != null)
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
            if (Vector2.Angle(contact.normal, Vector2.up) < 45f)
            {
                isGrounded = true;
                // Jump is a Trigger, so no SetBool needed here.
                // Optionally reset triggers if you used them elsewhere:
                // if (animator != null) animator.ResetTrigger(jumpingParam);
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Leaving contact likely means not grounded
        isGrounded = false;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
