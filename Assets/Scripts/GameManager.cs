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
    public GameObject PauseGame;
    private bool paused = false;

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
            PauseGameMenu();

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

    void PauseGameMenu()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }

        if (paused)
        {
            if (Input.GetKeyDown("r"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                paused = false;
            }

            else if (Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                PauseGame.SetActive(false);
                paused = false;
            }

            else if (Input.GetKeyDown("m"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                paused = false;
            }
        }

    }

}
