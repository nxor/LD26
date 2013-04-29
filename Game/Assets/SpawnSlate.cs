using UnityEngine;
using System.Collections;

public class SpawnSlate : MonoBehaviour {
	
	public GameObject[] slate;
	
	public int numberOfSlateToSpawn = 100;
	
	public float slateWidth = 1.0f;
	
	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	void Spawn()
	{
		int random = 0;
		int prevRandom = 0;
		for(int i=0;i<numberOfSlateToSpawn;i++)
		{
			while(random==prevRandom)
			{
				random = Random.Range(0,slate.Length);
			}
			
			GameObject go = Instantiate(slate[random],new Vector3(transform.position.x+(i*slateWidth),transform.position.y,transform.position.z),Quaternion.identity) as GameObject;
			go.transform.localScale = new Vector3(slateWidth,go.transform.localScale.y,go.transform.localScale.z);
			
			prevRandom = random;
		}		
	}
	
}