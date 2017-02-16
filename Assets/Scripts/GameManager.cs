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
	private Camera mainCamera;

    public Vector3 startPos = new Vector3(0, 0, 0);

    public static bool isTimeFrozen = false;
	public AudioClip slowTimeSound,slowTimeSoundDone;

	private AudioSource gameEffectSource;

    // Use this for initialization
    void Start () {
        pool = GameObject.FindGameObjectWithTag("ObstaclePool").GetComponent<ObjectPooling>();
		currentPlayerZCoord = player.transform.position.z;
		mainCamera = Camera.main;

		foreach(AudioSource sound in mainCamera.GetComponents<AudioSource>()) {
			if(sound.isPlaying){
				continue;
			}
			gameEffectSource = sound;
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
        if(Input.GetKeyUp(KeyCode.F8))
        {
            PlayerPrefs.SetFloat("quicksave-x", player.transform.position.x);
            PlayerPrefs.SetFloat("quicksave-y", player.transform.position.y);
            PlayerPrefs.SetFloat("quicksave-z", player.transform.position.z);
            PlayerPrefs.SetInt("health", player.GetComponent<Player>().healthManager.currentHealth);
            print("saved");
        }
        if(Input.GetKeyUp(KeyCode.F11))
        {
            print("loading...");
            if (PlayerPrefs.HasKey("quicksave-x") &&
                PlayerPrefs.HasKey("quicksave-y") &&
                PlayerPrefs.HasKey("quicksave-z"))
            {
                Vector3 quicksavedPos = new Vector3(
                    PlayerPrefs.GetFloat("quicksave-x"),
                    PlayerPrefs.GetFloat("quicksave-y"),
                    PlayerPrefs.GetFloat("quicksave-z"));
                player.transform.position = quicksavedPos;
                player.GetComponent<Player>().healthManager.currentHealth = PlayerPrefs.GetInt("health");
                print("load complete");
            }
            else
            {
                print("key missing");
            }
           
        }
	}
    void chunkUpdateTrack(){
		if ((playerMoved / chunkLoadDist) > chunksLoaded ) {
			//print ("Called Spawn Chunk!" + chunksLoaded);
			for (int i = 0; i < objectsToSpawn; i++) {
                obj = pool.RetrieveInstance();
				if (obj) {
					obj.transform.position = startPos +
					new Vector3 (Random.Range (minX, maxX), 3,
							player.transform.position.z + Random.Range (50, 50 + chunkLoadDist));
				}
			}
			chunksLoaded = chunksLoaded + 1;
		}
	}

    public void stopTime(float length)
    {
        StartCoroutine(StopTime(length));
    }
    private IEnumerator StopTime(float length)
    {
		mainCamera.GetComponent<AudioSource> ().pitch = 0.5f;
		gameEffectSource.PlayOneShot (slowTimeSound);
        print("Freezing time!");
        isTimeFrozen = true;
        yield return new WaitForSeconds(length);
		gameEffectSource.PlayOneShot (slowTimeSoundDone);
        print("Unfreezing time!");
        isTimeFrozen = false;
		mainCamera.GetComponent<AudioSource> ().pitch = 1.0f;
    }
}
