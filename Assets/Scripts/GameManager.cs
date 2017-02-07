using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnableObject {
	public int spawnWeight;
	public GameObject gameObj;
}
public class GameManager : MonoBehaviour {
	public SpawnableObject[] obstacles;
	public GameObject player;
	public GameObject pauseMenu;
    public static int HealthPacks = 1;
	public int objectsToSpawn = 120;

	public int totalWeights = 0;

	public float pauseCooldown = 0.3f;

	public float chunkLoadDist = 5;
	private int chunksLoaded = 0;

	private float playerMoved = 0;
	private float currentPlayerZCoord = 0;

	// Use this for initialization
	void Start () {
		foreach (SpawnableObject obstacle in obstacles){
			totalWeights += obstacle.spawnWeight;
		}

		currentPlayerZCoord = player.transform.position.z;

		for (int i = 0; i < objectsToSpawn; i++) {
			int selectedIdx = Random.Range (0, totalWeights);
			print (selectedIdx);
			foreach (SpawnableObject obstacle in obstacles) {
				selectedIdx -= obstacle.spawnWeight;
				print (selectedIdx);
				if (selectedIdx < 1) {
					GameObject obj = Instantiate (obstacle.gameObj, player.transform.position
						+ new Vector3 (Random.Range(-5,5), Random.Range(0,2), Random.Range(10,250)),
						Quaternion.AngleAxis(90, Vector3.up));
					break;
				}
			}
			//obj.transform.localScale += new Vector3(Random.Range (0.5f, 1.5f),Random.Range (0.2f, 1.2f),Random.Range (0.5f, 1.5f));
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			print ("Key Pressed");
			if (!pauseMenu.activeSelf) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
			pauseMenu.SetActive (!pauseMenu.activeSelf);
		}
		if (player.transform.position.z > currentPlayerZCoord) {
			playerMoved += (player.transform.position.z - currentPlayerZCoord);
			currentPlayerZCoord = player.transform.position.z;
			chunkUpdateTrack ();
		}
	}
	void chunkUpdateTrack(){
		print ("Called Spawn Chunk!");
		if ((playerMoved / chunkLoadDist) > chunksLoaded ) {
			for (int i = 0; i < objectsToSpawn; i++) {
				int selectedIdx = Random.Range (0, totalWeights);
				print (selectedIdx);
				foreach (SpawnableObject obstacle in obstacles) {
					selectedIdx -= obstacle.spawnWeight;
					if (selectedIdx < 1) {
						GameObject obj = Instantiate (obstacle.gameObj, player.transform.position
							+ new Vector3 (Random.Range(-5,5), Random.Range(0,2), Random.Range(10,250)),
							Quaternion.AngleAxis(90, Vector3.up));
						break;
					}
				}
				//obj.transform.localScale += new Vector3(Random.Range (0.5f, 1.5f),Random.Range (0.2f, 1.2f),Random.Range (0.5f, 1.5f));
			}
			chunksLoaded = chunksLoaded + 1;
		}
		
		
	}
}
