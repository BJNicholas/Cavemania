using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float speed;
    public float jumpForce;
    Vector3 inputs;

    Rigidbody2D rb;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = 0;

        inputs = inputs.normalized * speed * Time.deltaTime;

        if(inputs.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (inputs.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
            print("JUMP!");
        }
    }

    private void FixedUpdate()
    {
        transform.position += inputs;

    }
}
