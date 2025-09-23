using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BalloonUp : MonoBehaviour
{
    public float speed = 3.0f;
    public float upperBound = 17f;
    public ScoreManager scoreManager; // Reference the scoremanager
    public Balloon balloon; //Reference the balloon script to get the score value

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        balloon = gameObject.GetComponent<Balloon>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); // Move the balloon upwards
        
        if (transform.position.y >= upperBound) //check if balloon goes out of bounds
        {
            scoreManager.DecreaseScore(balloon.scoreToGive); // Deduct points if the balloon goes out of bounds
            Destroy(gameObject); // Destroy the balloon if it goes out of bounds
        }
    }
}
