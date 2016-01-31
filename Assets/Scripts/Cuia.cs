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

			GameObject pai = GameObject.Find("Pai");
			pai.GetComponent<CameraControl2D>().offSet.x += 0.5f;
	
			if ((Camera.main.transform.localPosition.x + ((Camera.main.GetComponent<Camera>().orthographicSize*2.2))) < pai.transform.position.x) {
				managerScript.playerWon = true;
				other.gameObject.GetComponent<Avatar>().speed = 0;
				other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				Destroy(pai);
			}

			Destroy(this.gameObject);
		}
	}

	void Update () {
	
	}
}
