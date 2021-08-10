using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
	public GameObject player;
	public int currentDistance;
	
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(currentDistance >= 50f)
		{
			//Instantiate Checkpoint.
			//Lock Spawner
			
		}
		else{
			
			//Move Checkpoint Spawner.
			
		}
    }
}
