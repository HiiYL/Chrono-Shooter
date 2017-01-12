﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

    public GameObject explosion;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        if (other.tag == "Player")
        {
            // Die!
            Destroy(gameObject);
            Debug.Log("Health Pack!!");
        }

        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }

    }
}
