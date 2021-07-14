using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBallScript : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float countdown = 0;
    private void Update()
    {
        countdown += 1;
        rb.AddForce(Vector2.down * speed);


        if(countdown >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
