using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {
    private Animation animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animation>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.isTimeFrozen && animator.isPlaying)
        {
            animator.Stop();
        }
        if(!GameManager.isTimeFrozen && !animator.isPlaying)
        {
            animator.Play();
        }
		
	}
}
