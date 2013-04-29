using UnityEngine;
using System.Collections;

public class RetryButton : MonoBehaviour {
	
	public GameObject gameManager;
	// Use this for initialization
	void OnMouseDown()
	{
		StartCoroutine(Retry());
	}
	
	IEnumerator Retry()
	{
		yield return new WaitForSeconds(0.5f);
		gameManager.GetComponent<GameManager>().HideMenu();
		gameManager.GetComponent<GameManager>().Retry();
		
	}
}
