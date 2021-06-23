using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float score = 0;
    float yPos;
    public float healthLossRate;

    public float health;

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

        if(health <= 0)
        {
            PlayerController.instance.gameObject.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<CircleCollider2D>().enabled = false;
            player.transform.Rotate(0, 0, 3);

            CameraController.instance.target = CameraController.instance.gameObject;
        }
        else
        {
            yPos = -player.transform.position.y;
            ScoreCheck();
        }
    }

    void ScoreCheck()
    {
        if(yPos > score)
        {
            score = yPos;
        }
    }

}
