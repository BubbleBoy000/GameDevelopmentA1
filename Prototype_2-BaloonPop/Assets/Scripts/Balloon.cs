using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Balloon : MonoBehaviour
{
    public int clicksToPop = 3; // Number of clicks required to pop the balloon
    private float scaleToIncrease = 0.15f; // Amount to increase the scale on each click
    public int scoreToGive; // Score to give when the balloon is popped
    private ScoreManager scoreManager; // Reference to the ScoreManager script
    public GameObject popEffect; // Particle effect prefab to instantiate on pop

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Updates every click
    void OnMouseDown()
    {
        //Reduce clicks by one
        clicksToPop -= 1;
        //increase the size of the balloon
        transform.localScale += Vector3.one * scaleToIncrease;

        //Check if the balloon should pop
        if (clicksToPop == 0)
        {
            scoreManager.IncreaseScore(scoreToGive); //Increase the score
            if (popEffect != null)
            {
                Instantiate(popEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject); //Destroy the balloon
        }
    }
    
}
