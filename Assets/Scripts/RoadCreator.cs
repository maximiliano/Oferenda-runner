using UnityEngine;
using System.Collections;

public class RoadCreator : MonoBehaviour {

	public GameObject firstTile;
	public float endOfRoadX;
	//public GameObject camera;
	public GameObject[] tiles;


	void Start () {
		//GameObject road = GameObject.Find("Road");

		if (endOfRoadX == 0) {
			//Bounds roadBounds = road.GetComponent<MeshRenderer>().bounds;
		//	Bounds roadBounds = road.GetComponent<BoxCollider>().bounds;
		//	Vector3 endOfRoad = new Vector3(roadBounds.center.x - roadBounds.extents.x, 0, 0);

			Vector3 endOfRoad = new Vector3(firstTile.GetComponent<BoxCollider>().center.x - firstTile.GetComponent<BoxCollider>().size.x, 0, 0);
		}

	}

	void drawTile() {
		Vector3 newPosition = new Vector3(endOfRoadX, 0, 0);
		GameObject randomTile = tiles[Random.Range(0, tiles.Length)];
		GameObject tileInstance = (GameObject)Instantiate(randomTile, newPosition, Quaternion.identity);
		endOfRoadX -= randomTile.GetComponent<BoxCollider>().size.x;
	}

	void Update () {
		
		if ((Camera.main.transform.localPosition.x - ((Camera.main.GetComponent<Camera>().orthographicSize*3))) < endOfRoadX ) 
    	{
			drawTile();
		}
	}
}
