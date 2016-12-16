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

	void OnTriggerEnter(Collider other){
		print (other.tag);
		if (other.gameObject.tag == "Obstacle") {
            Vector3 trans = transform.position;
            trans.y += 5;
			Instantiate (explosion, trans, Quaternion.identity);

//			Destroy (col.gameObject);
		}
		
	}
}
