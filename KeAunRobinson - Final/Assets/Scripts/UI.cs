using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	GameController gc;
	//bool isStartMenu = true;
	Text text;
	Text hints;
	//float textTime;

	public void StartGameMethod(){
		Application.LoadLevel(1);
	}

	void Awake(){
		if(Application.loadedLevel != 0)
			text = GameObject.FindWithTag("Info").GetComponent<Text>();
		else if (Application.loadedLevel >= 1){
			text = GameObject.Find("Canvas").GetComponentInChildren<Text>();

		}
	}

	void Start () {
		hints = GameObject.FindGameObjectWithTag("Hint").GetComponent<Text>() as Text;
		gc = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	}
		public void Display(){
			text.text = "Score-->  " + gc.score + "\n" + "Deaths-->  " + gc.deaths;
		}

	public void UiHints(){
			if (Collectibles.hasMap == false)
				hints.text = "Find a map to get started. Maps are look like a yellow square";
			
		if (Collectibles.hasMap == true){
				//textTime = Time.time;
				Destroy(hints, 5.0f);
				hints.text = "Now get the Objects of the Green Orb Dieties to move on into the World of Nothingness.\n" +
				"Watch out for the Debased God of Red and Mohawk-Hating Sphere's attacks!";
		}
	}
}