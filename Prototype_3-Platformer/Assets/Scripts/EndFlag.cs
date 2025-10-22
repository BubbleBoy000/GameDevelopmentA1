using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class EndFlag : MonoBehaviour
{
    public bool finalLevel;
    public string nextLevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Did the player collide with the end flag?
        if (collision.CompareTag("Player"))
        {
            // If this is the final level, go to the menu
            if (finalLevel == true)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                // Load the next level
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}
