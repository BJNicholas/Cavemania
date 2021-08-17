using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberScript : MonoBehaviour
{
    public float damage;
    public float speed;

    GameObject player;
    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        //deletion stuff
        if (player.transform.position.y < transform.position.y - 10)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            turn();
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * speed);
    }

    void turn()
    {
        rb.velocity = Vector2.zero;
        speed = -speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.health -= damage;
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Wall")
        {
            turn();
        }
    }
}
