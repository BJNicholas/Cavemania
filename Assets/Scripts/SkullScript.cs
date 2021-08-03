using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour
{
    public float speed;
    public AudioClip biteSound;
    public AudioClip flyingSound;

    Rigidbody2D rb;
    GameObject player;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (player.transform.position.y < transform.position.y - 30)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.health -= 1;

            GetComponent<AudioSource>().clip = biteSound;
            if (GetComponent<AudioSource>().isPlaying == false && GetComponent<AudioSource>().clip == biteSound)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().clip = flyingSound;
            GetComponent<AudioSource>().Play();

        }
    }
}
