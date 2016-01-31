using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject avatar;
	public bool avatarIsDead = false;
	public bool playerWon = false;
	public int score = 0;
	public int currentHighscore;
	public GameObject gameOverPanel;
	public GameObject winPanel;
	public GameObject menuPanel;
	public GameObject creditsPanel;

	void Start () {
		currentHighscore = PlayerPrefs.GetInt("highscore");
	}

	void registerScore() {
		if (score > currentHighscore) {
			PlayerPrefs.SetInt("highscore", score);
			currentHighscore = score;
		}

		GameObject scoreObj = GameObject.Find("Score");
		scoreObj.GetComponent<Text>().text = "Score: " + score;

		GameObject highscoreObj = GameObject.Find("Highscore");
		highscoreObj.GetComponent<Text>().text = "Highscore: " + currentHighscore;
	}

	void checkDeath() {
		if (avatarIsDead) {
			avatar.SetActive(false);
			gameOverPanel.SetActive(true);
			registerScore();
		}
	}

	void checkWin() {
		if (playerWon) {
			winPanel.SetActive(true);
			registerScore();
		}
	}

	void Update () {
		checkDeath();
		checkWin();
	}

	public void PlayAgain() {
		Application.LoadLevel("Main");
	}

	public void Menu() {
		Application.LoadLevel("Menu");
	}

	public void InGameMenu() {
		Time.timeScale = 0;
		if (creditsPanel.activeInHierarchy) {
			creditsPanel.SetActive(false);
		}
		menuPanel.SetActive(true);
	}

	public void ContinueGame() {
		Time.timeScale = 1;
		menuPanel.SetActive(false);
	}

	public void ShowCredits() {
		menuPanel.SetActive(false);
		creditsPanel.SetActive(true);
	}

	public void QuitGame() {
		Application.Quit();
	}


}
