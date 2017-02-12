﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
	public SpawnableObject[] obstacles;
	public GameObject player;
	public GameObject pauseMenu;
    public static int HealthPacks = 1;
	public int objectsToSpawn = 120;

	

	public float pauseCooldown = 0.3f;

	public float chunkLoadDist = 5;
	private int chunksLoaded = 0;

	private float playerMoved = 0;
	private float currentPlayerZCoord = 0;

    private int totalWeights = 0;
    private ObjectPooling pool;
    private GameObject obj;

    // Use this for initialization
    void Start () {
        pool = GameObject.FindGameObjectWithTag("ObstaclePool").GetComponent<ObjectPooling>();
        foreach (SpawnableObject obstacle in obstacles){
			totalWeights += obstacle.spawnWeight;
		}

		currentPlayerZCoord = player.transform.position.z;


		for (int i = 0; i < objectsToSpawn; i++) {
            obj = pool.RetrieveInstance();
            if (obj)
            {
                obj.transform.position = player.transform.position + new Vector3(Random.Range(-5, 5), Random.Range(0, 2), Random.Range(10, 250));
            }
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
                obj = pool.RetrieveInstance();
                if (obj)
                {
                    obj.transform.position = player.transform.position + new Vector3(Random.Range(-5, 5), Random.Range(0, 2), Random.Range(10, 250));
                }
			}
			chunksLoaded = chunksLoaded + 1;
		}
	}
}
