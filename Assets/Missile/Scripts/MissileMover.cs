using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMover : MonoBehaviour {
    public float speed;
//	public Vector3 emptyVector;
    // Use this for initialization
    void Start () {
//        GetComponent<Rigidbody>().velocity = transform.forward * speed;

//		emptyVector = new Vector3 (0, 0, 0);
    }
	void Update() {
//		GetComponent<Rigidbody> ().velocity = emptyVector;
		transform.position += transform.forward * speed * Time.deltaTime;
	}

}
