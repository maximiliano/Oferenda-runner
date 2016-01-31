using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {
	public int speed;
	public int jumpingForce;
	public bool isGrounded;
	public bool doubleJumped = false;
	public bool collidedObstacle = false;

	// Use this for initialization

	Animator _animator;

	void Start () {
		_animator = gameObject.GetComponent<Animator>();
	}


	void OnCollisionEnter(Collision collision) {
		isGrounded = true;
		doubleJumped = false;

		if (collision.gameObject.CompareTag("Obstacle")) {
			collidedObstacle = true;
		}

//		void OnTriggerEnter(Collider other) {
//		if (other.gameObject.CompareTag("Avatar")) {
//			GameManager managerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
//			managerScript.score += 1;
//			GameObject scoreBoard = GameObject.Find("ScoreBoard");
//			scoreBoard.GetComponent<Text>().text = "Score: " + managerScript.score;
//
//			GameObject pai = GameObject.Find("Pai");
//			pai.GetComponent<CameraControl2D>().offSet.x += 0.5f;
//
//			if ((Camera.main.transform.localPosition.x + ((Camera.main.GetComponent<Camera>().orthographicSize*2.2))) < pai.transform.position.x) {
//				managerScript.playerWon = true;
//				other.gameObject.GetComponent<Avatar>().speed = 0;
//				other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
//				Destroy(pai);
//			}
//
//			Destroy(this.gameObject);
//		}
//	}
//
	}

	void OnCollisionStay(Collision collision) {
		isGrounded = true;
	}

	void OnCollisionExit(Collision collision) {
		isGrounded = false;

		if (collision.gameObject.CompareTag("Obstacle")) {
			collidedObstacle = false;
		}
	}

	void bringFatherCloser() {
		GameManager managerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		GameObject pai = GameObject.Find("Pai");
		pai.GetComponent<CameraControl2D>().offSet.x -= 0.1f;
		if (pai.GetComponent<CameraControl2D>().offSet.x <= 0) {
			managerScript.avatarIsDead = true;
		}
	}

	// Update is called once per frame
	void Update () {

		_animator.SetBool("Ground", isGrounded);

		bool enteredJumpInput = Input.GetKeyDown(KeyCode.UpArrow) || 
			                    Input.GetKeyDown(KeyCode.Space) || 
			                    Input.GetKeyDown(KeyCode.Mouse0);
		if (isGrounded && enteredJumpInput) {
			this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
		}
		if (isGrounded == false && doubleJumped == false && enteredJumpInput) {
			this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce/2);
			doubleJumped = true;
		}

		this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime,
		                                      this.transform.position.y, 
		                                      this.transform.position.z);

		if (this.transform.position.y < 0) {
            GameObject.Find("GameManager").GetComponent<GameManager>().avatarIsDead = true;
		}

		if (collidedObstacle) {
			bringFatherCloser();
		}
	}
}
