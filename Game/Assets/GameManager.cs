using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject spawner;
	
	public float stepDuration = 2.0f;
	
	public float difficulty = 1.0f;
	
	// Use this for initialization
	void Start () {
				
		spawner.GetComponent<SpawnSlate>().slateWidth 			= 3.0f;
					
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("slate"))
		{
			go.GetComponent<SlateMovement>().speed 				= 1.0f;
		}
		
		InvokeRepeating("IncreaseDifficulty",stepDuration,stepDuration);
		
		
	}
	
	// Update is called once per frame
	void IncreaseDifficulty()
	{
		difficulty += 0.1f;
							
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("slate"))
		{
			go.GetComponent<SlateMovement>().speed 				= 1.0f + difficulty;
		}
	}
}
