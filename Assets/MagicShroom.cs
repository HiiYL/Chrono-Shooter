using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShroom : MonoBehaviour {
    public float length = 20f;

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
		
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
            gameManager.stopTime(length);
            gameObject.SetActive(false);
           
        }

    }


}
