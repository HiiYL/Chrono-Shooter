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
    public static int HealthPacks = 1;
	public int objectsToSpawn = 120;

	public int totalWeights = 0;

	// Use this for initialization
	void Start () {
		foreach (SpawnableObject obstacle in obstacles){
			totalWeights += obstacle.spawnWeight;
		}

		for (int i = 0; i < objectsToSpawn; i++) {
			GameObject gameObjectToSpawn;

			int selectedIdx = Random.Range (0, totalWeights);
			print (selectedIdx);
			foreach (SpawnableObject obstacle in obstacles) {
				selectedIdx -= obstacle.spawnWeight;
				print (selectedIdx);
				if (selectedIdx < 1) {
					GameObject obj = Instantiate (obstacle.gameObj, player.transform.position
						+ new Vector3 (Random.Range(-5,5), Random.Range(0,2), Random.Range(10,400)),
						Quaternion.AngleAxis(90, Vector3.up));
					break;
				}
			}
			print ("");

			//obj.transform.localScale += new Vector3(Random.Range (0.5f, 1.5f),Random.Range (0.2f, 1.2f),Random.Range (0.5f, 1.5f));
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
