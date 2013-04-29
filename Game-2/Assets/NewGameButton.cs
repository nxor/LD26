using UnityEngine;
using System.Collections;

public class NewGameButton : MonoBehaviour {
	
	public GameObject gameManager;
	// Use this for initialization
	void OnMouseDown()
	{
		StartCoroutine(NewGame());
	}
	
	IEnumerator NewGame()
	{
		yield return new WaitForSeconds(0.5f);
		gameManager.GetComponent<GameManager>().HideMenu();
		gameManager.GetComponent<GameManager>().StartGame();
		
	}
}
