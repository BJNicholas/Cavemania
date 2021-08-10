using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerV2 : MonoBehaviour
{
	public GameObject[] prefabs;
	public GameManager gameinstance;
	public static SpawnerV2	instance;
	public float spawnDistance;
	GameObject player;
	public GameObject organiser;
	public int totalPrefabs;
	GameObject currentPrefab;
	
    void Start()
    {
		instance = this;
		gameinstance = GameManager.instance.GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
		SpawnPrefab();
    }

    void Update()
    {
		if(player.transform.position.y - transform.position.y < spawnDistance)
		{
			SpawnPrefab();
		}
    }
	
	void SpawnPrefab()
	{
		GameObject newPrefab = null;
		
		if(totalPrefabs < 2)
		{
			newPrefab = Instantiate(prefabs[Random.Range(0,prefabs.Length)],organiser.transform);
			newPrefab.transform.position = new Vector3(0,transform.position.y,0);
		}
		else{
			Destroy(newPrefab);
			totalPrefabs = 0;
		}


		transform.position -= new Vector3(0,1,0);
	}
}
