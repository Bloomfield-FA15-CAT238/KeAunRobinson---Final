using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlPoints : MonoBehaviour {

	GameController gc;
	//Text text;

	void Start(){
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		//text = GameObject.FindWithTag("Info").GetComponent<Text>();
	}

	public Transform respawn, finish;
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Player") && this.CompareTag("Respawn")){
			gc.deaths += 1;
			other.gameObject.transform.position = respawn.transform.position;
		}
		else if (other.gameObject.CompareTag("Player") && this.CompareTag("Finish") && gc.score == 10)
			Application.LoadLevel(2);
		else if (other.gameObject.CompareTag("Player") && this.CompareTag("Finish") && gc.deaths >= 4)
			gc.DeletePrefs();
			Application.Quit();
	}
}
