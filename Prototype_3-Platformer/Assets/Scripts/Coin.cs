using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour
{
    public int scoreToGive; // How many points does the player get
    private float startYPos; // Coin start position on the Y axis
    public float bobbingSpeed; // Speed of the coin's bobbing motion
    public float bobbingHeight; // Height of the coin's bobbing motion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that collided with the coin has the tag "Player"
        if(collision.CompareTag("Player"))
        {
            // Add score to the player
            collision.GetComponent<PlayerController2D>().AddScore(scoreToGive);
            // Destroy the coin
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startYPos = transform.position.y; // Set the starting Y pos to the current Y pos
    }

    // Update is called once per frame
    void Update()
    {
        //Bob the coin up and down
        float newY = startYPos + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        transform.position = new Vector3(transform.position.x, newY, 0);
    }
}
