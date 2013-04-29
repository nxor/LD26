using UnityEngine;
using System.Collections;

public class CreditButton : MonoBehaviour {
	
	public GameObject uiCredit;
	
	// Use this for initialization
	void OnMouseDown()
	{
		StartCoroutine(Credit());
	}
	
	IEnumerator Credit()
	{
		yield return new WaitForSeconds(1.0f);
		uiCredit.SetActive(true);		
	}
}
