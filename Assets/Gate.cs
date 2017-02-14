﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour {
    public string nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider myTrigger)
    {
        if (myTrigger.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
