using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject explosion;
    public HealthManager healthManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //void OnTriggerEnter(Collider other){


    //}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Obstacle-Bomb")
        {
            Vector3 trans = transform.position;
            trans.y += 5;
            Instantiate(explosion, trans, Quaternion.identity);
            healthManager.Health -= 1;
			if (collision.gameObject.tag == "Obstacle-Bomb") {
				collision.gameObject.transform.rotation = Quaternion.identity;
				collision.gameObject.transform.Rotate (0, 180, 0);
			}
			collision.gameObject.SetActive (false);
            //			Destroy (col.gameObject);
        }
    }
}
