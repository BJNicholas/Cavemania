using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickUpScript : MonoBehaviour
{
    public float manaValue;

    GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (player.transform.position.y < transform.position.y - 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.mana += manaValue;
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
