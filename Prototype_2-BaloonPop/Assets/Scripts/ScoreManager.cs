using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; // Import TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public int score; //Keep track of score
    public TextMeshProUGUI scoreText; //Reference UI text

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0; //Initialize score to 0
        UpdateScoreText(); //Reset UI text
    }

    public void IncreaseScore(int amount)
    {
        score += amount; //Increase score by amount
        UpdateScoreText(); //Update UI text
    }

    public void DecreaseScore(int amount)
    {
        score -= amount; //Decrease score by amount
        UpdateScoreText(); //Update UI text
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); //Update UI text
    }
}
