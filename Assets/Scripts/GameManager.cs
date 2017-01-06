using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject[] obstacles;
	public GameObject player;


	// Use this for initialization
	void Start () {
		int length = obstacles.Length;
		for (int i = 0; i < 120; i++) {
			GameObject obj = Instantiate (obstacles[Random.Range(0,length)], player.transform.position
				+ new Vector3 (Random.Range(-5,5), Random.Range(0,2), Random.Range(10,400)), Quaternion.AngleAxis(90, Vector3.up));
			
			//obj.transform.localScale += new Vector3(Random.Range (0.5f, 1.5f),Random.Range (0.2f, 1.2f),Random.Range (0.5f, 1.5f));
			
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
