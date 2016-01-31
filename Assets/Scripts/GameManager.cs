using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject avatar;
	public bool avatarIsDead = false;
	public int score = 0;

	void Start () {
	}
	
	void checkDeath() {
		if (avatarIsDead) {
			Application.LoadLevel("Menu");
		}
	}

	void Update () {
		checkDeath();
	}
}
