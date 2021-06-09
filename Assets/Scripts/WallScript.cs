using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(GameManager.instance.health > 0)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y);
        }
    }
}
