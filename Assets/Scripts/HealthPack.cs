using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
    private HealthManager healthManager;

    // Use this for initialization
    void Start () {
        healthManager = FindObjectOfType<HealthManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Boundary" || tag == "Enemy")
        {
            return;
        }

        if (tag == "Player")
        {
			gameObject.SetActive (false);
            Debug.Log("Health Pack!!");
            healthManager.Health += 1;
        }

    }
}
