using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float score = 0;

    public float health;

    GameObject player;

    private void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        if(health <= 0)
        {
            PlayerController.instance.gameObject.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.transform.Rotate(0, 0, 10);

            CameraController.instance.target = CameraController.instance.gameObject;
        }
        else
        {
            score = -player.transform.position.y;
        }
    }

}
