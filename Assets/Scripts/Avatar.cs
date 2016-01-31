using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {
	public int speed;
	public int jumpingForce;
	public bool isGrounded;

	// Use this for initialization

	Animator _animator;

	void Start () {
		_animator = gameObject.GetComponent<Animator>();
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

		_animator.SetBool("Ground",isGrounded);

		if(isGrounded )
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
			this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
		}
		
		this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime,
		                                      this.transform.position.y, 
		                                      this.transform.position.z);

		if (this.transform.position.y < 0) {
            GameObject.Find("GameManager").GetComponent<GameManager>().avatarIsDead = true;
		}
	}
}
