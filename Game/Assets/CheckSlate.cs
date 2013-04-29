using UnityEngine;
using System.Collections;

public class CheckSlate : MonoBehaviour {
	
	public enum checkType {Early, Correct, Late};
	public checkType currentType;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
	 switch (currentType)
        {
            case checkType.Early:
            {
			Debug.Log("Early");
			break;
			}
            case checkType.Correct:
            {
			Debug.Log("Correct");
			break;
			}
            case checkType.Late:
            {
			Debug.Log("Late");
			break;
			}			
		}
			
	}
}
