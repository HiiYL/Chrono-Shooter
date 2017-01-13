using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Rotate (0, 0, -34.883f);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * 90f);
		
	}
}
