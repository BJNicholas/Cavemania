using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        if(Input.GetKeyDown("R"))
        {
            Debug.Log("Replaying Game...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    public void ToMainMenu()
    {
        if (Input.GetKeyDown("M"))
        {
            Debug.Log("Returning to Main Menu...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

}
