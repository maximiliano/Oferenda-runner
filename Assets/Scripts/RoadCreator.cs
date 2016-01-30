using UnityEngine;
using System.Collections;

public class RoadCreator : MonoBehaviour {

	public float endOfRoadX;
	public GameObject roadTile;
	public GameObject[] obstacles;
	public float tileSize;
	public bool lastTileWasEmpty = false;
	public int totalTiles = 0;

	void Start () {
		tileSize = roadTile.GetComponent<BoxCollider>().size.x;
	}

	void drawTile() {
		int chanceOfHole = Random.Range(0, 100);

		if (chanceOfHole <= 30 && lastTileWasEmpty == false && totalTiles > 10) {
			endOfRoadX -= tileSize;
			lastTileWasEmpty = true;
		} else {
			Vector3 newPosition = new Vector3(endOfRoadX, 0, 0);
			GameObject tileInstance = (GameObject)Instantiate(roadTile, newPosition, Quaternion.identity);
			endOfRoadX -= tileSize;
			lastTileWasEmpty = false;

			int chanceOfObstacle = Random.Range(0, 100);
			if (chanceOfObstacle <= 15 && totalTiles > 10) {
				BoxCollider tileCollider = tileInstance.GetComponent<BoxCollider>();

				GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
				float ySize = randomObstacle.GetComponent<BoxCollider>().size.y;

				Vector3 obstaclePosition = new Vector3(tileCollider.transform.position.x,
			    	                                   tileCollider.transform.position.y + tileCollider.size.y + ySize/2,
			        	                               tileCollider.transform.position.z);

				GameObject obstacleInstance = (GameObject)Instantiate(randomObstacle, obstaclePosition, Quaternion.identity);
			}
		}
		totalTiles += 1;
	}

	void Update () {
		if ((Camera.main.transform.localPosition.x - ((Camera.main.GetComponent<Camera>().orthographicSize * 3))) < endOfRoadX ) {
			drawTile();
		}
	}
}
