using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject avatar;
	public bool avatarIsDead = false;
	public int score = 0;
	public int currentHighscore;
	public GameObject gameOverPanel;

	void Start () {
		currentHighscore = PlayerPrefs.GetInt("highscore");
	}
	
	void checkDeath() {
		if (avatarIsDead) {
			avatar.SetActive(false);
			gameOverPanel.SetActive(true);

			if (score > currentHighscore) {
				PlayerPrefs.SetInt("highscore", score);
				currentHighscore = score;
			}

			GameObject scoreObj = GameObject.Find("Score");
			scoreObj.GetComponent<Text>().text = "Score: " + score;

			GameObject highscoreObj = GameObject.Find("Highscore");
			highscoreObj.GetComponent<Text>().text = "Highscore: " + currentHighscore;
		}
	}

	void Update () {
		checkDeath();
	}

	public void PlayAgain() {
		Application.LoadLevel("Main");
	}

	public void Menu() {
		Application.LoadLevel("Menu");
	}

	public void QuitGame() {
		Application.Quit();
	}

}
