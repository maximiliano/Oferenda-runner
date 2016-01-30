using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {
	public int speed;
	public int jumpingForce;
	public bool isGrounded;
	// Use this for initialization
	void Start () {
	
	}


	void OnCollisionEnter(Collision collision) {

		isGrounded = true;

	}

	void OnCollisionStay(Collision collision) {

		isGrounded = true;

	}

	void OnCollisionExit(Collision collision) {

		isGrounded = false;

	}

	// Update is called once per frame
	void Update () {

		if(isGrounded )
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) {
			this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
		}

//		GameObject camera = GameObject.Find("Main Camera");
//
//		camera.transform.position = new Vector3(camera.transform.position.x - speed * Time.deltaTime,
//		                                        camera.transform.position.y, 
//		                                        camera.transform.position.z);
		
		this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime,
		                                      this.transform.position.y, 
		                                      this.transform.position.z);
	}
}
