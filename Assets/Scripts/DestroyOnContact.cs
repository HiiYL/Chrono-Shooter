using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class DestroyOnContact : MonoBehaviour {
    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            //Destroy(other.gameObject);
			gameObject.SetActive(false);
        }

        if (other.tag == "Obstacle-Bomb")
        {
            if (explosion != null)
            {
                GameObject explosionObj = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
                explosionObj.GetComponent<ExplosionPhysicsForce>().explosionForce = 3;
                explosionObj.GetComponent<ParticleSystemMultiplier>().multiplier = 4;
            }
			other.gameObject.SetActive(false);
			gameObject.SetActive (false);
        }

    }
}
