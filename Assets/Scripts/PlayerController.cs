using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [Header("Stats")]
    public float speed;
    public float jumpForce;
    [Range(0, 1)]
    public float gravityEffectOnPlayer = 1;


    public Vector3 inputs;
    public bool jumping = false;
    Rigidbody2D rb;

    [Header("Weapon details")]
    public GameObject firePoint;
    public GameObject fireObject;
    public float rateOfFire;

    [Header("Audio Clips")]
    public AudioClip jumpSound;
    public AudioClip runSound;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = 0;

        inputs = inputs * speed * Time.deltaTime;
        
    }
    float coolDown = 0;
    private void FixedUpdate()
    {
        print(rb.velocity.y);
        coolDown += 1;
        //"Jumping"
        if (Input.GetKey(KeyCode.Space) && GameManager.instance.mana != 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jumping = true;
            GameManager.instance.mana -= 1f;
            gravityEffectOnPlayer = 0;

            if(coolDown >= rateOfFire)
            {
                GameObject slimeBall = Instantiate(fireObject);
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().clip = jumpSound;
                GetComponent<AudioSource>().Play();
                slimeBall.transform.position = firePoint.transform.position;
                coolDown = 0;
            }
            
        }
        else
        {
            gravityEffectOnPlayer = Mathf.Lerp(gravityEffectOnPlayer, 1, 0.1f);
            if (gravityEffectOnPlayer >= 0.99f)
            {
                jumping = false;
            }
        }
        //Gravity

        rb.AddForce(Vector2.up * (-GameManager.instance.gravityStrength * gravityEffectOnPlayer));

        //left/right movement
        rb.MovePosition(new Vector2(transform.position.x + inputs.x, transform.position.y));

        //counter movement when not inputing for snappier stops
        if(inputs.x == 0 )
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        
    }

    //collision detection 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Wall")
        {
            gravityEffectOnPlayer = 0;
        }
        else
        {
            gravityEffectOnPlayer = 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        gravityEffectOnPlayer = 1;
    }
}
