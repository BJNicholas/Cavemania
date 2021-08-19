using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    private Animator anim;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
        
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jumped");
        }

        if(isGrounded == true)
        {
            anim.SetBool("isfalling", false);
        }
        else
        {
            anim.SetBool("isfalling", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("takedamage");
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("takedamage");
        }

    }
}
