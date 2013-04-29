using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

	// Use this for initialization
	void OnMouseDown()
	{
		StartCoroutine(Exit());
	}
	
	IEnumerator Exit()
	{
		yield return new WaitForSeconds(1.0f);
		Debug.Log("EXIT");
		Application.Quit();
	}
}
