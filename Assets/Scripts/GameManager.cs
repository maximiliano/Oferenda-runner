using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject avatar;
	public bool avatarIsDead = false;

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
