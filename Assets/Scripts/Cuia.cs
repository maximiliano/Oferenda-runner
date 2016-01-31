using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cuia : MonoBehaviour {


	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Avatar")) {
			GameObject.Find("GameManager").GetComponent<GameManager>().score += 1;
			GameObject scoreBoard = GameObject.Find("ScoreBoard");
			scoreBoard.GetComponent<Text>().text = "Score: " + GameObject.Find("GameManager").GetComponent<GameManager>().score;
			Destroy(this.gameObject);
		}
	}

	void Update () {
	
	}
}
