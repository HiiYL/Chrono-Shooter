using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

    public GameObject explosion;
    private HealthManager healthManager;

    // Use this for initialization
    void Start () {
        healthManager = FindObjectOfType<HealthManager>();
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
            Destroy(gameObject);
            Debug.Log("Health Pack!!");
            healthManager.Health += 1;
        }
        else if (other.tag == "Projectile")
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
