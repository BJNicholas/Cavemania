using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [Range(1,10)]
    public int decoyChance;
    [Range(1, 10)]
    public int emberChance;
    public GameObject ember;
    public bool isDecoy = false;
    public bool canBeDecoy = true;

    public GameObject demonBox;

    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (canBeDecoy)
        {
            int roll = Random.Range(0, decoyChance);
            if (roll == 0)
            {
                isDecoy = true;
            }
            int dice = Random.Range(0, emberChance);
            if (dice == 0)
            {
                GameObject flame = Instantiate(ember, transform);
                flame.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            }
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
        if(collision.gameObject.tag == "Pickup")
        {
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            Destroy(collision.gameObject);
        }
    }
}
