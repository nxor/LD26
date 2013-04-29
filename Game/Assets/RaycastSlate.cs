using UnityEngine;
using System.Collections;

public class RaycastSlate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0F))
		{
            float distanceToGround = hit.distance;
			Debug.Log(distanceToGround);
		}
	
	}
}
