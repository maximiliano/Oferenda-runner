using UnityEngine;
using System.Collections;

public class RoadCreator : MonoBehaviour {

	public GameObject firstTile;
	public float endOfRoadX;
	//public GameObject camera;
	public GameObject roadTile;
	public float tileSize;
	public bool lastTileWasEmpty = false;
	public int totalTiles = 0;

	void Start () {
		if (endOfRoadX == 0) {
			Vector3 endOfRoad = new Vector3(firstTile.GetComponent<BoxCollider>().center.x - firstTile.GetComponent<BoxCollider>().size.x, 0, 0);
			tileSize = firstTile.GetComponent<BoxCollider>().size.x;
		}
	}

	void drawTile() {
		int chanceOfHole = Random.Range(0, 100);
		int chanceOfObstacle = Random.Range(0, 100);

		Debug.Log("Chance of Hole: " + chanceOfHole);

		if (chanceOfHole <= 30 && lastTileWasEmpty == false && totalTiles > 10) {
			endOfRoadX -= tileSize;
			lastTileWasEmpty = true;
		} else if (chanceOfObstacle <= 30 && totalTiles > 10) {
			
		} else {
			Vector3 newPosition = new Vector3(endOfRoadX, 0, 0);
			GameObject tileInstance = (GameObject)Instantiate(roadTile, newPosition, Quaternion.identity);
			endOfRoadX -= tileInstance.GetComponent<BoxCollider>().size.x;
			lastTileWasEmpty = false;
		}
		totalTiles += 1;
	}

	void Update () {
		if ((Camera.main.transform.localPosition.x - ((Camera.main.GetComponent<Camera>().orthographicSize * 3))) < endOfRoadX ) {
			drawTile();
		}
	}
}
