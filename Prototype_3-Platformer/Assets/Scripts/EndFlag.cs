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
        if (!collision.CompareTag("Player"))
            return;

        if (finalLevel)
        {
            SceneManager.LoadScene(0);
            return;
        }

        if (!string.IsNullOrEmpty(nextLevelName))
        {
            SceneManager.LoadScene(nextLevelName);
            return;
        }

        // fallback: load next scene in build order if nextLevelName not provided
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            Debug.LogWarning("EndFlag: nextLevelName empty and no next scene in Build Settings.");
    }
}
