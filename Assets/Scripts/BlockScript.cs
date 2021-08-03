using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [Range(1,10)]
    public int decoyChance;
    public bool isDecoy = false;

    public GameObject demonBox;

    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int roll = Random.Range(0, decoyChance);
        if(roll == 0)
        {
            isDecoy = true;
        }
    }

    private void Update()
    {
        if(player.transform.position.y < transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (isDecoy)
            {
                GameObject spawnedBox = Instantiate(demonBox, transform.position, transform.rotation);
                Destroy(gameObject);

                GameManager.instance.health -= 10;
            }
        }
    }
}
