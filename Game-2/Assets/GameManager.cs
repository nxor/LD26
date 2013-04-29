using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public GameObject uiCamera;
	public GameObject hudCamera;
	public GameObject loseCamera;
	
	public GameObject hudLevelNumber;
	public GameObject hudHighestLevelNumber;
	
	public GameObject[] buttonList;
	public List<int> myList = new List<int>();
	public int currentIndex = 0;
	
	public enum GameStateType {AutomaticPlay, PlayerInput}; 
	public GameStateType gameState;
	
	public int currentLevel = 1;
	public int highestLevel = 1;
	
	// Use this for initialization
	void Start () {
		//Show menu
		ShowMenu();		
	}
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(uiCamera.activeSelf)
			{
				HideMenu();
			}
			else
			{
				ShowMenu();
			}
		}
		
		switch (gameState)
        {
            case GameStateType.AutomaticPlay:
            {
				foreach(GameObject button in buttonList)
				{
					button.GetComponent<MoveWhenPressed>().playerInputEnable = false;
				}
				break;
            }
            case GameStateType.PlayerInput:
            {
				foreach(GameObject button in buttonList)
				{
					button.GetComponent<MoveWhenPressed>().playerInputEnable = true;
				}
                break;
            }
        }	
		
		hudLevelNumber.GetComponent<UILabel>().text = currentLevel.ToString();
		hudHighestLevelNumber.GetComponent<UILabel>().text = highestLevel.ToString();
	}
	
	public void StartGame()
	{
		int randomValue;
		
		currentIndex = 0;
		currentLevel = 1;
		myList.Clear();
		for(int i=0;i<=currentLevel;i++)
		{
			randomValue = Random.Range(0,4);	
			myList.Add(randomValue);
		}
		
		StartCoroutine(PlaySong());
    }
	
	void AddStep()
	{
		int randomValue;
		
		randomValue = Random.Range(0,4);	
		myList.Add(randomValue);
    }
 
    public IEnumerator PlaySong()
    {
		gameState = GameStateType.AutomaticPlay;
		yield return new WaitForSeconds(1.0f);		
        for (int x = 0; x <myList.Count ; x ++)
        {
			buttonList[myList[x]].GetComponent<MoveWhenPressed>().PressButton();
            yield return new WaitForSeconds(1.0f);
			buttonList[myList[x]].GetComponent<MoveWhenPressed>().ReleaseButton();
			yield return new WaitForSeconds(0.5f);
        }
		gameState = GameStateType.PlayerInput;
    }
	
	public IEnumerator SwitchLevel()
    {
		gameState = GameStateType.AutomaticPlay;
		yield return new WaitForSeconds(1.0f);			
		currentIndex=0;	
		currentLevel++;
		highestLevel++;
		AddStep();
		StartCoroutine(PlaySong());
    }
	
	public IEnumerator WrongIndicator()
    {
		gameState = GameStateType.AutomaticPlay;
		yield return new WaitForSeconds(1.0f);			
		loseCamera.SetActive(true);	
    }	
	
	public void ButtonPressedByPlayer(GameObject go)
	{
		if(go != buttonList[myList[currentIndex]])
		{
			StartCoroutine(WrongIndicator());	
		}
		else{
			currentIndex++;
			if(currentIndex>=myList.Count)
			{
				Debug.Log("GOOD ! Next Level :D");
				StartCoroutine(SwitchLevel());
			}
		}
	}
	
	public void HideMenu()
	{
		uiCamera.SetActive(false);
		hudCamera.SetActive(true);
		loseCamera.SetActive(false);
	}
	
	public void ShowMenu()
	{
		uiCamera.SetActive(true);
		hudCamera.SetActive(false);
		loseCamera.SetActive(false);
	}	
	
	public void Retry()
	{
		currentIndex = 0;
		StartCoroutine(PlaySong());
	}
}
