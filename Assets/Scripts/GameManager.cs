using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject pauseMenu;
    public static int HealthPacks = 1;
	public int objectsToSpawn = 120;

    public float minX = -3.37f;
    public float maxX = 3.5f;

	

	public float pauseCooldown = 0.3f;

	public float chunkLoadDist = 5;
	private int chunksLoaded = 0;

	private float playerMoved = 0;
	private float currentPlayerZCoord = 0;

    private int totalWeights = 0;
    private ObjectPooling pool;
    private GameObject obj;

    public Vector3 startPos = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        pool = GameObject.FindGameObjectWithTag("ObstaclePool").GetComponent<ObjectPooling>();
		currentPlayerZCoord = player.transform.position.z;
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
		if ((playerMoved / chunkLoadDist) > chunksLoaded ) {
			print ("Called Spawn Chunk!" + chunksLoaded);
			for (int i = 0; i < objectsToSpawn; i++) {
                obj = pool.RetrieveInstance();
				if (obj) {
					obj.transform.position = startPos +
					new Vector3 (Random.Range (minX, maxX), 2,
							player.transform.position.z + Random.Range (50, 50 + chunkLoadDist));
				}
			}
			chunksLoaded = chunksLoaded + 1;
		}
	}
}
