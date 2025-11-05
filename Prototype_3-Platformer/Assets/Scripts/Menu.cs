using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1); //Loads Scene
    }

    // Update is called once per frame
    public void OnQuitButton() 
    {
        Application.Quit(); //Quits Game      
    }
}
