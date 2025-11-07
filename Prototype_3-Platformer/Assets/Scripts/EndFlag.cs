using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class EndFlag : MonoBehaviour
{
    public bool finalLevel;
    public string nextLevelName;

    private void Start()
    {
        Debug.Log($"EndFlag: initialized (finalLevel={finalLevel}, nextLevelName='{nextLevelName}')");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"EndFlag: OnTriggerEnter2D with '{collision.name}' (tag='{collision.tag}')");

        if (!collision.CompareTag("Player"))
        {
            Debug.Log("EndFlag: collider is not Player, ignoring.");
            return;
        }

        // optional: sanity-check player component
        var player = collision.GetComponent<PlayerController2D>();
        if (player == null)
        {
            Debug.LogWarning("EndFlag: collided object has Player tag but no PlayerController2D component.");
        }

        if (finalLevel == true)
        {
            Debug.Log("EndFlag: finalLevel -> load scene 0");
            SceneManager.LoadScene(0);
            return;
        }

        if (!string.IsNullOrEmpty(nextLevelName))
        {
            Debug.Log($"EndFlag: loading scene by name '{nextLevelName}'");
            SceneManager.LoadScene(nextLevelName);
            return;
        }

        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log($"EndFlag: loading next scene index {nextIndex}");
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.LogWarning("EndFlag: nextLevelName empty and no next scene in Build Settings.");
        }
    }
}
