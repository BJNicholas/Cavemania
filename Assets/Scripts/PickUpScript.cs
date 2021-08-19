using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
        }
    }
}
