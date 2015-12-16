using UnityEngine;
using System.Collections;

public class Collectibles : MonoBehaviour {

	public GameObject map;
	public static bool hasMap = false;
	GameController gc;
	Camera mapCamera;
	MeshRenderer isMapVisable; 

	// Use this for initialization
	void Start () {
		//map = GameObject.FindWithTag("Map");
		gc = GameObject.Find("GameController").GetComponent<GameController>();
		mapCamera = map.GetComponentInChildren<Camera>();
		mapCamera.enabled = false;
		isMapVisable = map.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		var player = GameObject.FindGameObjectWithTag("Player") as GameObject;
		mapCamera.transform.position = player.transform.position + new Vector3(0, 5, 0);
	
	}

	void OnTriggerEnter(Collider other){
		if (this.gameObject.CompareTag("Map") && other.gameObject.CompareTag("Player")){
			hasMap = true;
			if (hasMap){
				isMapVisable.enabled = false;
				mapCamera.enabled = true;
				mapCamera.transform.position = other.transform.position + new Vector3(0, 5, 0);
			}
		}
		else if (this.gameObject.CompareTag("Collectible") && other.gameObject.CompareTag("Player")){
			gc.score += 10;
			GameObject.Destroy(this.gameObject);
		}
	}
}
