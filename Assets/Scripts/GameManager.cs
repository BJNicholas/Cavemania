using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Game Variables")]
    public float score = 0;
    public float bankedScore;
    float yPos;
    public float gravityStrength;
    public float healthLossRate;
    [Header("Player Stats")]
    public float health;
    public float mana;

    GameObject player;
    [Header("UI")]
    public GameObject GameOverMenu;
    public Text trueScore;
    public Text pickupBonus;                                           
    public GameObject PauseMenu;
    public GameObject HowToPlayMenu;
    [Header("Sprites")]
    public Sprite slimeHurt;

    bool isPaused = true;
    bool tutorialOn = true;

    private void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        Time.timeScale = 0;
    }
    private void FixedUpdate()
    {
        health -= healthLossRate * (health / 100);
        health = Mathf.Clamp(health, 0, 100);

        trueScore.text = score.ToString("00");
        pickupBonus.text = bankedScore.ToString();
        if (health <= 0)
        {
            if (bankedScore > 0)
            {
                bankedScore -= 1;
                score += 1;
            }
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            PlayerController.instance.gameObject.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<SpriteRenderer>().sprite = slimeHurt;
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<CircleCollider2D>().enabled = false;
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.transform.Rotate(0, 0, 3);
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (-gravityStrength * Time.deltaTime));

            CameraController.instance.target = CameraController.instance.gameObject;

            GameOverMenu.SetActive(true);
            GameOver();
        }
        else
        {
            yPos = -player.transform.position.y;
            ScoreCheck();

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(true);
                tutorialOn = false;
                PauseGame();
            }
            if(isPaused && !tutorialOn)
            {
                if(Input.GetKeyDown("r"))
                {
                    RestartGame();
                }
                else if(Input.GetKeyDown("m"))
                {
                    MainMenu();
                }
            }
        }
        //clamp values
        health = Mathf.Clamp(health, 0, 100);
        mana = Mathf.Clamp(mana, 0, 100);
    }

    void ScoreCheck()
    {
        if(yPos > score)
        {
            score = yPos;
        }
    }

    public void GameOver()
    {
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if(Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    void PauseGame()
    {
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                HowToPlayMenu.SetActive(false);
                isPaused = false;
            }

        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        isPaused = false;
    }

}