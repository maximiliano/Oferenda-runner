using UnityEngine;
using System.Collections;

public class ButtonActions : MonoBehaviour {

	public void ChangeScene(string scene) {
		Application.LoadLevel(scene);
	}
}
