using UnityEngine;
using System.Collections;

public class RoadCreator : MonoBehaviour {

	public float endOfRoadX;
	public GameObject roadTile;
	public GameObject obstacle;
	public float tileSize;
	public bool lastTileWasEmpty = false;
	public int totalTiles = 0;
	public int obstacleChance = 15;

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
			if (chanceOfObstacle <= obstacleChance && totalTiles > 10) {
				BoxCollider tileCollider = tileInstance.GetComponent<BoxCollider>();

				float obstacleHeight = obstacle.GetComponent<BoxCollider>().size.y;
				Vector3 obstaclePosition = new Vector3(tileCollider.transform.position.x,
				                                       tileCollider.transform.position.y + tileCollider.size.y + obstacleHeight/2,
			        	                               tileCollider.transform.position.z);

				GameObject obstacleInstance = (GameObject)Instantiate(obstacle, obstaclePosition, Quaternion.identity);
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
