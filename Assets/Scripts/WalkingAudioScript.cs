using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAudioScript : MonoBehaviour
{
    private void Update()
    {
        if(PlayerController.instance.inputs.x == 0)
        {
            GetComponent<AudioSource>().Pause();
        }
        else
        {
            GetComponent<AudioSource>().UnPause();
        }

        if(GameManager.instance.health <= 0)
        {
            GetComponent<AudioSource>().Pause();
        }
    }
}
