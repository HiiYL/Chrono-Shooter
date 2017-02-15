using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class bombMover : MonoBehaviour {
    public int maxBoxSpeed = 30;
    public int minBoxSpeed = 25;

    public float detectionRangeMin = 25;
    public float detectionRangeMax = 40;
    public float correctionSpeed = 1f;
	public GameObject explosion;

    private float boxSpeed;
    private float detectionRange;
    private GameObject player;
    private Quaternion rotation;

    // Use this for initialization
    void Start () {
        boxSpeed = Random.Range(minBoxSpeed, maxBoxSpeed);
        detectionRange = Random.Range(detectionRangeMin, detectionRangeMax);

        player = GameObject.FindGameObjectWithTag("Player");
        

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 rot = transform.rotation.eulerAngles;
        if(rot[1] < 90 || rot[1] > 270)
        {
            destroySelf();
        }
        if (Vector3.Distance(player.transform.position, transform.position) < detectionRange)
        {
			rotation = Quaternion.LookRotation(player.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * correctionSpeed);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * boxSpeed);
    }

    void destroySelf()
    {
        if (explosion != null)
        {
            GameObject explosionObj = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
            explosionObj.GetComponent<ExplosionPhysicsForce>().explosionForce = 20;
            //explosionObj.GetComponent<ParticleSystemMultiplier> ().multiplier = 3;
        }
        if (gameObject.GetComponent<TrailRenderer>())
        {
            gameObject.GetComponent<TrailRenderer>().Clear();
        }
        gameObject.SetActive(false);
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 8) {
            destroySelf();
        }
	}
}
