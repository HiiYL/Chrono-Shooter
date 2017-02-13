using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class bombMover : MonoBehaviour {
    public int maxBoxSpeed = 30;
    public int minBoxSpeed = 25;

    public float detectionRange = 25;
	public float correctionSpeed = 1f;
	public GameObject explosion;

    private float boxSpeed;
    private GameObject player;
    private Quaternion rotation;

    // Use this for initialization
    void Start () {
        boxSpeed = Random.Range(minBoxSpeed, maxBoxSpeed);

        player = GameObject.FindGameObjectWithTag("Player");
        

    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, transform.position) < detectionRange)
        {
			rotation = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * correctionSpeed);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * boxSpeed);
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground") {
			if (explosion != null) {
				GameObject explosionObj = (GameObject)Instantiate (explosion, transform.position, transform.rotation);
				explosionObj.GetComponent<ExplosionPhysicsForce> ().explosionForce = 2;
				explosionObj.GetComponent<ParticleSystemMultiplier> ().multiplier = 3;
			}
			gameObject.transform.rotation = Quaternion.identity;
			gameObject.transform.Rotate (0, 180, 0);
			gameObject.SetActive (false);
		}
	}
}
