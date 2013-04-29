using UnityEngine;
using System.Collections;

public class SpaceActivateSound : MonoBehaviour {
	
	public Color[] availableColor;
	
	void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("A key or mouse click has been detected");
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("slate"))
			{
				go.GetComponent<Slate>().currentColor = 	
			}			
		}
		
        
    }
}
