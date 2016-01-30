using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

         if ((Camera.main.transform.localPosition.x + ((Camera.main.GetComponent<Camera>().orthographicSize*3))) < transform.position.x ) 
		    {
			Destroy (this.gameObject);
			}

	}
}
