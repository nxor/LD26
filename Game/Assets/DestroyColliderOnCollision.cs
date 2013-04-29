using UnityEngine;
using System.Collections;

public class DestroyColliderOnCollision : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider collider)
	{
		Destroy (collider.gameObject);
	}
}
