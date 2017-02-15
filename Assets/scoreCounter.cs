using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour {
    private float score = 0;

    private float currentPlayerZCoord = 0;

    public GameObject player;
    private Text txtRef;

    private float updateAccuracy = 0.1f;
    private float currentAccumulated = 0f;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        txtRef = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.z > currentPlayerZCoord)
        {
            currentAccumulated += (player.transform.position.z - currentPlayerZCoord);
            currentPlayerZCoord = player.transform.position.z;
            if (currentAccumulated > updateAccuracy)
            {
                txtRef.text = "Distance: " + currentPlayerZCoord.ToString("F1") + " m";
                currentAccumulated = 0f;
            }
        }
        
    }
}
