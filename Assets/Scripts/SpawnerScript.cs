using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] blocks;
    public float spawnDistance;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SpawnBlock();
    }

    private void Update()
    {
        if(player.transform.position.y - transform.position.y < spawnDistance)
        {
            SpawnBlock();
        }
    }

    void SpawnBlock()
    {
        GameObject newBlock = Instantiate(blocks[Random.Range(0,2)]);
        newBlock.transform.position = new Vector3(Random.Range(-7, 8), transform.position.y, 0);

        transform.position -= new Vector3(0, 1, 0);
    }
	
}
