using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public UI userinterface;
	public int score, deaths;


	void Awake(){
		score = 0;
		deaths = 0;
		SetPlayerPrefs();

	}

	void Start () {
		userinterface = GameObject.FindObjectOfType<Canvas>().GetComponent<UI>() as UI;

	}
	
	// Update is called once per frame
	void Update () {
		userinterface.Display();
		userinterface.UiHints();
		//make list of game object that hold the score and the map. call map and enabled 2nd camera for map
	}

	public void SetPlayerPrefs(){
		PlayerPrefs.SetInt ("score", score);
		PlayerPrefs.SetInt ("deaths", deaths);
	}

	public void GetPlayerPrefs(){
		PlayerPrefs.GetInt ("score");
		PlayerPrefs.GetInt ("deaths");
	}

	public void DeletePrefs(){
		PlayerPrefs.DeleteAll();
	}


}
