using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject obstacle;
	public GameObject player;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 150; i++) {
			GameObject obj = Instantiate (obstacle, player.transform.position
				+ new Vector3 (Random.Range(-5,5), Random.Range(1,2), Random.Range(10,300)), Quaternion.identity);
			
			obj.transform.localScale += new Vector3(Random.Range (0.5f, 1.5f),Random.Range (0.5f, 1.5f),Random.Range (0.5f, 1.5f));
			
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
