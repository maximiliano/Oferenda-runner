using UnityEngine;
using System.Collections;

public class RoadCreator : MonoBehaviour {

	public float endOfRoadX;
	public float roadTileY;
	public float roadTileZ;
	public float endOfBuildingX;
	public GameObject roadTile;
	public GameObject lastRoadTile;
	public GameObject lastBuilding;
	public GameObject obstacle;
	public GameObject item;
	public GameObject ceil;
	public GameObject[] buildings;
	public float tileSize;
	public bool lastTileWasEmpty = false;
	public int totalTiles = 0;
	public int obstacleChance = 15;
	public int itemChance = 15;


	void Start () {
//		tileSize = roadTile.GetComponent<BoxCollider>().size.x;
		BoxCollider tileCollider = lastRoadTile.GetComponent<BoxCollider>();
		tileSize = tileCollider.size.x;
		roadTileZ = lastRoadTile.transform.position.y + tileCollider.size.y / 2;
		roadTileZ = lastRoadTile.transform.position.z + tileCollider.size.z / 2;

		BoxCollider buildingCollider = lastBuilding.GetComponent<BoxCollider>();
		endOfBuildingX = buildingCollider.transform.position.x - buildingCollider.size.x / 2;
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

		int chanceOfItem = Random.Range(0, 100);
		if (chanceOfHole <= itemChance) {
			Vector3 itemPosition = new Vector3(endOfRoadX, Random.Range(2, 8), 0);
			GameObject itemInstance = (GameObject)Instantiate(item, itemPosition, Quaternion.identity);
		}

		totalTiles += 1;
	}

	void drawCeil() {
		Vector3 newPosition = new Vector3(endOfRoadX, 
			                              ceil.GetComponent<BoxCollider>().size.y * 9, 0);
		GameObject ceilInstance = (GameObject)Instantiate(ceil, newPosition, Quaternion.identity);
	}

	void drawBuilding() {
		GameObject building = buildings[Random.Range(0, buildings.Length)];
		Debug.Log(building.name);
		BoxCollider buildingCollider = building.GetComponent<BoxCollider>();

		Vector3 newPosition = new Vector3(endOfBuildingX - buildingCollider.size.x / 2,
		                                  roadTileY, 
//		                                  9);
		                                  roadTileZ + buildingCollider.size.z / 2);
		GameObject tileInstance = (GameObject)Instantiate(building, newPosition, Quaternion.identity);
		endOfBuildingX = tileInstance.transform.position.x - buildingCollider.size.x / 2;
	}

	void Update () {
		if ((Camera.main.transform.localPosition.x - ((Camera.main.GetComponent<Camera>().orthographicSize * 3))) < endOfRoadX ) {
			drawTile();
			drawCeil();
		}
		if ((Camera.main.transform.localPosition.x - ((Camera.main.GetComponent<Camera>().orthographicSize * 3))) < endOfBuildingX) {
			drawBuilding();
		}
	}
}
