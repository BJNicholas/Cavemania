using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
	public List<string> itemsNames = new List<string>();
	public GameManager manager;
	public GameObject player;
	public float scoreTracker;
	
	
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		AddItems();
		manager = GameManager.instance.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
		/*{
			Debug.Log("YEah");
		}*/
    }
	
	void AddItems()
	{
		itemsNames.Add("Mana Up");
		itemsNames.Add("HP up");
		itemsNames.Add("Heavy Weights");
		itemsNames.Add("Star Rounds");
	}
	
	
}
