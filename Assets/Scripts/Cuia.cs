using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cuia : MonoBehaviour {


	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Avatar")) {
			GameManager managerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
			managerScript.score += 1;
			GameObject scoreBoard = GameObject.Find("ScoreBoard");
			scoreBoard.GetComponent<Text>().text = "Score: " + managerScript.score;

			Destroy(this.gameObject);
		}
	}

	void Update () {
	
	}
}
