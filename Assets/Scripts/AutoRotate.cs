using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
    private Vector3 towardsBack;

    // Use this for initialization
    void Start () {
        towardsBack = new Vector3(0, 0, -25);
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(towardsBack), 0.015F);
    }
}
