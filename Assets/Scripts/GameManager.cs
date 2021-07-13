using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float score = 0;
    float yPos;
    public float gravityStrength;
    public float healthLossRate;

    public float health;
    public float mana;

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
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.transform.Rotate(0, 0, 3);
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (-gravityStrength * Time.deltaTime));

            CameraController.instance.target = CameraController.instance.gameObject;
        }
        else
        {
            yPos = -player.transform.position.y;
            ScoreCheck();
        }

        if(PlayerController.instance.jumping == false)
        {
            mana += 0.1f;
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

}
