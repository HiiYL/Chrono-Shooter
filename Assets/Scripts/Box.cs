using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
	public int maxBoxSpeed = 1;
	public int minBoxSpeed = 7;


	public float boxSpeed;
	public MoveBehaviour moveBehaviour = MoveBehaviour.Straight;

	public enum MoveBehaviour {
		Left,
		Right,
		Straight
	}

	// Use this for initialization
	void Start () {
		boxSpeed = Random.Range (minBoxSpeed, maxBoxSpeed);
		
	}

	public void setMoveBehaviour(MoveBehaviour mb) {
		moveBehaviour = mb;
	}
	
	// Update is called once per frame
	void Update () {
		switch (moveBehaviour) {
		case(MoveBehaviour.Left):
			transform.position += new Vector3 (-boxSpeed * Time.deltaTime, 0, 0);
			break;
		case(MoveBehaviour.Right):
			transform.position += new Vector3 (boxSpeed * Time.deltaTime, 0, 0);
			break;
		case(MoveBehaviour.Straight):
			transform.position += new Vector3 (0, 0, -boxSpeed * Time.deltaTime);
			break;
		}
	}
}
