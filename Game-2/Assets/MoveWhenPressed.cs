using UnityEngine;
using System.Collections;

public class MoveWhenPressed : MonoBehaviour {
	public GameObject gameManager;
	public enum GameStateType {AutomaticPlay, PlayerInput};
	
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 2.0F;
    private float startTime;
    private float journeyLength;
    public float smooth = 5.0F;
	
	public Transform startTarget;
	public Transform endTarget;
	
	public bool lerpEnable = false;
	public bool playerInputEnable = false;
	
	public AudioSource audioSource;
	
    void Start() {
		startTarget = transform;
		endTarget = transform;
		startTime = Time.time;
        journeyLength = 1.0f;		
    }
    void Update() {    
		if(journeyLength>0)
		{
			float distCovered = (Time.time - startTime) * speed;
	        float fracJourney = distCovered / journeyLength;
	        transform.position = Vector3.Lerp(startTarget.position, endTarget.position, fracJourney);
		}
    }
	
	void OnMouseDown() {
		if(playerInputEnable)
		{
			PressButton();
			gameManager.SendMessage("ButtonPressedByPlayer",gameObject,SendMessageOptions.DontRequireReceiver);
		}
    }
	
	void OnMouseUp() {
			ReleaseButton();
    }
	
	public void PressButton()
	{
		startTarget = transform;
		endTarget = endMarker;
		
        startTime = Time.time;
        journeyLength = Vector3.Distance(startTarget.position, endTarget.position);	
		audioSource.Play();
	}
	
	public void ReleaseButton()
	{
		startTarget = transform;
		endTarget = startMarker;
		
        startTime = Time.time;
        journeyLength = Vector3.Distance(startTarget.position, endTarget.position);		
	}
}
