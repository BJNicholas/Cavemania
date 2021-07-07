using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float score = 0;
    float yPos;
    public float healthLossRate;

    public float health;
    public GameObject GameOver;

    GameObject player;

    private void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        health -= healthLossRate * (health / 100);
        health = Mathf.Clamp(health, 0, 100);
    }

    private void Update()
    {

        if (health <= 0)
        {
            PlayerController.instance.gameObject.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<CircleCollider2D>().enabled = false;
            player.transform.Rotate(0, 0, 3);

            CameraController.instance.target = CameraController.instance.gameObject;

            GameOverMenu();
        }
        else
        {
            yPos = -player.transform.position.y;
            ScoreCheck();
        }
    }

    void ScoreCheck()
    {
        if (yPos > score)
        {
            score = yPos;
        }
    }

    void GameOverMenu()
    {
        GameOver.SetActive(true);

        if (Input.GetKeyDown("r"))
        {
            Debug.Log("Replaying Game...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (Input.GetKeyDown("m"))
        {
            Debug.Log("Returning to Main Menu...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

}
