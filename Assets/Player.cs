using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col){
		print (col.gameObject.tag);
		if (col.gameObject.tag == "Obstacle") {
			Instantiate (explosion, transform.position, Quaternion.identity);

//			Destroy (col.gameObject);
		}
		
	}
}
